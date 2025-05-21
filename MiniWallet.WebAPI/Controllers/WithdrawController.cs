using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MiniWallet.Domain.Features.WithDrawServices;


namespace MiniWallet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly WithdrawService _withdrawService;

        public WithdrawController(WithdrawService withdrawService)
        {
            _withdrawService = withdrawService;
        }

        [HttpPost]

        public IActionResult Withdraw([FromBody] WithdrawRequestModel request)
        {
            var response = _withdrawService.Deposit(request);

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
