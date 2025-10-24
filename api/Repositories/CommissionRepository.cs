using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Repositories
{
    public class CommissionRepository : ICommissionRepository
    {
        public async Task<decimal> CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest)
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest)
        {
            throw new NotImplementedException();
        }
    }
}