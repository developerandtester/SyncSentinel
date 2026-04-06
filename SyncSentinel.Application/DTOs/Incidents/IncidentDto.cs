using SyncSentinel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Application.DTOs.Incidents
{
    public class IncidentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentPriority Priority { get; set; }
        public IncidentStatus Status { get; set; }
        public string SourceSystem { get; set; } = string.Empty;
        public string? ExternalReference { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? UpdatedUtc { get; set; }
    }
}
