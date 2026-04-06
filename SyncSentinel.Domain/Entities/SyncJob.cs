using SyncSentinel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Entities
{
    public class SyncJob
    {
        public Guid Id { get; set; }
        public Guid? IncidentId { get; set; }
        public JobType JobType { get; set; }
        public SyncJobStatus Status { get; set; }
        public string SourceSystem { get; set; } = string.Empty;
        public string TargetSystem { get; set; } = string.Empty;
        public int RetryCount { get; set; }
        public int MaxRetries { get; set; }
        public string Payload { get; set; } = string.Empty;
        public string? LastError { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime? LastAttemptUtc { get; set; }
        public DateTime? CompletedUtc { get; set; }

        public Incident? Incident { get; set; }
    }
}
