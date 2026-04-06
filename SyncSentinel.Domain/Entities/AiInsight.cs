using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Entities
{
    public class AiInsight
    {
        public Guid Id { get; set; }
        public Guid IncidentId { get; set; }
        public string InsightType { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public decimal? ConfidenceScore { get; set; }
        public DateTime CreatedUtc { get; set; }

        public Incident Incident { get; set; } = null!;
    }
}
