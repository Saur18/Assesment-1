using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Services
{
    public interface ICommissionService
    {
        Task<decimal> CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest);
        Task<decimal> CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest);
    }
}