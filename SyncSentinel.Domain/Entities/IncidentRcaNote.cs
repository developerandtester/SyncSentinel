using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Entities
{
    public class IncidentRcaNote
    {
        public Guid Id { get; set; }
        public Guid IncidentId { get; set; }
        public string Note { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedUtc { get; set; }

        public Incident Incident { get; set; } = null!;
    }
}
