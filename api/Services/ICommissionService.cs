using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Services
{
    public interface ICommissionService
    {
        decimal CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest);
        decimal CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest);
    }
}