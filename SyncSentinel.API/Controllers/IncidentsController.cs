using Microsoft.AspNetCore.Mvc;
using SyncSentinel.Application.DTOs.Incidents;
using SyncSentinel.Application.Interfaces;

namespace SyncSentinel.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentService _incidentService;

    public IncidentsController(IIncidentService incidentService)
    {
        _incidentService = incidentService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(IncidentDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IncidentDto>> Create(
        [FromBody] CreateIncidentRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var createdIncident = await _incidentService.CreateAsync(request, cancellationToken);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdIncident.Id },
                createdIncident);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<IncidentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<IncidentDto>>> GetAll(CancellationToken cancellationToken)
    {
        var incidents = await _incidentService.GetAllAsync(cancellationToken);
        return Ok(incidents);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(IncidentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IncidentDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var incident = await _incidentService.GetByIdAsync(id, cancellationToken);

        if (incident is null)
        {
            return NotFound(new { message = $"Incident with id '{id}' was not found." });
        }

        return Ok(incident);
    }
}