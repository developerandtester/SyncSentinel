using SyncSentinel.Application.DTOs.Incidents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Application.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentDto> CreateAsync(CreateIncidentRequest request, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<IncidentDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IncidentDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
