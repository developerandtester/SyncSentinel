using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Enums
{
    public enum SyncJobStatus
    {
        Pending = 1,
        InProgress = 2,
        Succeeded = 3,
        Failed = 4,
        Retrying = 5
    }
}
