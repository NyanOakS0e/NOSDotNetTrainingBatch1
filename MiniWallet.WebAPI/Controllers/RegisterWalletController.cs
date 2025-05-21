using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniWallet.Domain.Features.WalletServices;

namespace MiniWallet.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWalletController : ControllerBase
    {

        private readonly RegisterWalletService _registerWalletService;

        public RegisterWalletController(RegisterWalletService registerWalletService)
        {
            _registerWalletService = registerWalletService;
        }

        [HttpPost]
        public IActionResult RegisterController([FromBody] RegisterWalletRequestModel request)
        {
            var response = _registerWalletService.RegisterWallet(request);
            
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
