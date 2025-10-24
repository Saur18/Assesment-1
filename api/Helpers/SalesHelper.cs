using api.Domain.Entities;

namespace AvalphaTechnologies.CommissionCalculator.Helpers
{
    public static class SalesHelper
    {
        public static decimal CalculateSales(decimal percent, int salesCount, int salesAmount)
        {
            return (percent / 100) * salesCount * salesAmount;
        }

        public static bool CheckIfSalesValid(CommissionCalculationRequest request)
        {
            return request.LocalSalesCount >= 0 && request.ForeignSalesCount >= 0 && request.AverageSaleAmount >= 0;
        }
    }
}
