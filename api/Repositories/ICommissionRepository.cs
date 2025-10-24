using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;

namespace api.Repositories
{
    public interface ICommissionRepository
    {
        decimal CalculateAvalphaCommission(CommissionCalculationRequest calculationRequest);
        decimal CalculateCompetitorCommission(CommissionCalculationRequest calculationRequest);
    }
}