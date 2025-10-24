using api.Domain.Entities;
using api.Services;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionService : ICommissionService
    {
        public Task<decimal> CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
