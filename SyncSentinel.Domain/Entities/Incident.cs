using SyncSentinel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Entities
{
    public class Incident
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

        public ICollection<IncidentRcaNote> RcaNotes { get; set; } = new List<IncidentRcaNote>();
        public ICollection<SyncJob> SyncJobs { get; set; } = new List<SyncJob>();
        public ICollection<AiInsight> AiInsights { get; set; } = new List<AiInsight>();
    }
}
