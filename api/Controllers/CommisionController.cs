using api.Domain.Entities;
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
            return Ok(new CommissionCalculationResponse() { 
                AvalphaTechnologiesCommissionAmount = 999,
                CompetitorCommissionAmount = 100
            });
        }
    }
}
