using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Domain.Entities;
using api.Domain.Enums;

namespace api.Repositories
{
    public interface ICommissionRepository
    {
        decimal CalculateCommission(CommissionCalculationRequest calculationRequest, CommissionTypeEnum commissionTypeEnum);
    }
}