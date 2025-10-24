using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Enums;
using AvalphaTechnologies.CommissionCalculator.Domain.Config;
using AvalphaTechnologies.CommissionCalculator.Helpers;
using Microsoft.Extensions.Options;

namespace api.Repositories
{
    public class CommissionRepository : ICommissionRepository
    {
        private readonly CommissionPercentage _commission;
        
        public CommissionRepository(IOptions<CommissionPercentage> options)
        {
            _commission = options.Value;
        }
        public decimal CalculateCommission(CommissionCalculationRequest calculationRequest, CommissionTypeEnum commissionTypeEnum)
        {
            try
            {
                if (!SalesHelper.CheckIfSalesValid(calculationRequest))
                {
                    throw new InvalidOperationException("The sales count and amount should be greater than or equal to 0.");
                }

                decimal localPercent = commissionTypeEnum == CommissionTypeEnum.Avalpha ? _commission.AvalphaLocal : _commission.CompetitorLocal;
                decimal foreignPercent = commissionTypeEnum == CommissionTypeEnum.Avalpha ? _commission.AvalphaForeign : _commission.CompetitorForeign;

                decimal localSales = SalesHelper.CalculateSales(localPercent, calculationRequest.LocalSalesCount, calculationRequest.AverageSaleAmount);
                decimal foreignSales = SalesHelper.CalculateSales(foreignPercent, calculationRequest.ForeignSalesCount, calculationRequest.AverageSaleAmount);

                return localSales + foreignSales;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}