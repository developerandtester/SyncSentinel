using SyncSentinel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Application.DTOs.Incidents
{
    public class CreateIncidentRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IncidentPriority Priority { get; set; }
        public string SourceSystem { get; set; } = string.Empty;
        public string? ExternalReference { get; set; }
    }
}
