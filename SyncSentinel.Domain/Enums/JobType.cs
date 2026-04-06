using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSentinel.Domain.Enums
{
    public enum JobType
    {
        ProductSync = 1,
        InventorySync = 2,
        OrderSync = 3,
        CustomerSync = 4,
        PricingSync = 5
    }
}
