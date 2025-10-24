using api.Domain.Entities;
using api.Domain.Enums;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvalphaTechnologies.CommissionCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommisionController : ControllerBase
    {
        private readonly ICommissionService _commissionService;

        public CommisionController(ICommissionService commissionService)
        {
            _commissionService = commissionService;
        }

        [ProducesResponseType(typeof(CommissionCalculationResponse), 200)]
        [HttpPost]
        public IActionResult Calculate(CommissionCalculationRequest calculationRequest)
        {
            try
            {
                decimal avalphaCommission = _commissionService.CalculateCommission(calculationRequest, CommissionTypeEnum.Avalpha);
                decimal competitorCommission = _commissionService.CalculateCommission(calculationRequest, CommissionTypeEnum.Competitor);

                return Ok(new CommissionCalculationResponse()
                {
                    AvalphaTechnologiesCommissionAmount = avalphaCommission,
                    CompetitorCommissionAmount = competitorCommission
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
