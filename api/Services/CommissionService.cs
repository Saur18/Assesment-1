using api.Domain.Entities;
using api.Domain.Enums;
using api.Repositories;
using api.Services;

namespace AvalphaTechnologies.CommissionCalculator.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly ICommissionRepository _commissionRepository;

        public CommissionService(ICommissionRepository commissionRepository)
        {
            _commissionRepository = commissionRepository;
        }

        public decimal CalculateCommission(CommissionCalculationRequest calculationRequest, CommissionTypeEnum commissionTypeEnum)
        {
            try
            {
                return _commissionRepository.CalculateCommission(calculationRequest, commissionTypeEnum);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
