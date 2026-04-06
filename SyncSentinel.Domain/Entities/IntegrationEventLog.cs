using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Entities
{
    public class IntegrationEventLog
    {
        public Guid Id { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
        public string Payload { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedUtc { get; set; }
        public DateTime? PublishedUtc { get; set; }
        public string? Error { get; set; }
    }
}
