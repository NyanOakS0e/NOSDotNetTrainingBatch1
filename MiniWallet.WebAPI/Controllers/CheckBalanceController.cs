using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniWallet.Domain.Features.CheckBalanceServices;

namespace MiniWallet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckBalanceController : ControllerBase
    {
        private readonly CheckBalanceService _checkBalance;

        public CheckBalanceController(CheckBalanceService checkBalance)
        {
            _checkBalance = checkBalance;
        }

        [HttpPost]
        public IActionResult CheckBalance([FromBody] CheckBalanceRequestModel request)
        {
            var response = _checkBalance.CheckBalance(request);

            if(response.isSuccess)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
