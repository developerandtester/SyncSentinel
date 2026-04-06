using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Enums
{
    public enum IncidentStatus
    {
        Open = 1,
        Investigating = 2,
        Mitigated = 3,
        Resolved = 4,
        Closed = 5
    }
}
