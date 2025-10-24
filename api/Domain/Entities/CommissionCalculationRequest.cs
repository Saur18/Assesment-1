using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Domain.Entities
{
    public class CommissionCalculationRequest
    {
        public int LocalSalesCount { get; set; }
        public int ForeignSalesCount { get; set; }
        public decimal AverageSaleAmount { get; set; }
    }
}