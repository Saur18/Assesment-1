using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
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
        public decimal CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest)
        {
            try
            {
                if (!SalesHelper.CheckIfSalesValid(calculationRequest))
                {
                    throw new InvalidOperationException("The sales count and amount should be greater than or equal to 0");
                }

                decimal localSales = SalesHelper.CalculateSales(_commission.AvalphaLocal, calculationRequest.LocalSalesCount, calculationRequest.AverageSaleAmount);
                decimal foreignSales = SalesHelper.CalculateSales(_commission.AvalphaForeign, calculationRequest.ForeignSalesCount, calculationRequest.AverageSaleAmount);

                return localSales + foreignSales;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public decimal CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest)
        {
            try
            {
                if (!SalesHelper.CheckIfSalesValid(calculationRequest))
                {
                    throw new InvalidOperationException("The sales count and amount should be greater than or equal to 0");
                }

                decimal localSales = SalesHelper.CalculateSales(_commission.CompetitorLocal, calculationRequest.LocalSalesCount, calculationRequest.AverageSaleAmount);
                decimal foreignSales = SalesHelper.CalculateSales(_commission.CompetitorForeign, calculationRequest.ForeignSalesCount, calculationRequest.AverageSaleAmount);

                return localSales + foreignSales;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}