using Microsoft.EntityFrameworkCore;
using SyncSentinel.Application.DTOs.Incidents;
using SyncSentinel.Application.Interfaces;
using SyncSentinel.Domain.Entities;
using SyncSentinel.Domain.Enums;
using SyncSentinel.Infrastructure.Persistence;
using System;

namespace SyncSentinel.Application.Services;

public class IncidentService : IIncidentService
{
    private readonly AppDbContext _dbContext;

    public IncidentService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IncidentDto> CreateAsync(CreateIncidentRequest request, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            throw new ArgumentException("Incident title is required.");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ArgumentException("Incident description is required.");
        }

        if (string.IsNullOrWhiteSpace(request.SourceSystem))
        {
            throw new ArgumentException("Source system is required.");
        }

        var incident = new Incident
        {
            Id = Guid.NewGuid(),
            Title = request.Title.Trim(),
            Description = request.Description.Trim(),
            Priority = request.Priority,
            Status = IncidentStatus.Open,
            SourceSystem = request.SourceSystem.Trim(),
            ExternalReference = string.IsNullOrWhiteSpace(request.ExternalReference)
                ? null
                : request.ExternalReference.Trim(),
            CreatedUtc = DateTime.UtcNow
        };

        _dbContext.Incidents.Add(incident);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return MapToDto(incident);
    }

    public async Task<IReadOnlyList<IncidentDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var incidents = await _dbContext.Incidents
            .AsNoTracking()
            .OrderByDescending(x => x.CreatedUtc)
            .Select(x => new IncidentDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Priority = x.Priority,
                Status = x.Status,
                SourceSystem = x.SourceSystem,
                ExternalReference = x.ExternalReference,
                CreatedUtc = x.CreatedUtc,
                UpdatedUtc = x.UpdatedUtc
            })
            .ToListAsync(cancellationToken);

        return incidents;
    }

    public async Task<IncidentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Incidents
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new IncidentDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Priority = x.Priority,
                Status = x.Status,
                SourceSystem = x.SourceSystem,
                ExternalReference = x.ExternalReference,
                CreatedUtc = x.CreatedUtc,
                UpdatedUtc = x.UpdatedUtc
            })
            .FirstOrDefaultAsync(cancellationToken);
    }

    private static IncidentDto MapToDto(Incident incident)
    {
        return new IncidentDto
        {
            Id = incident.Id,
            Title = incident.Title,
            Description = incident.Description,
            Priority = incident.Priority,
            Status = incident.Status,
            SourceSystem = incident.SourceSystem,
            ExternalReference = incident.ExternalReference,
            CreatedUtc = incident.CreatedUtc,
            UpdatedUtc = incident.UpdatedUtc
        };
    }
}