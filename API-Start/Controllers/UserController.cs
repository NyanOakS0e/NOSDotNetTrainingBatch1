using API_Start.Models;
using API_Start.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using SQL_Services_Shared;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace API_Start.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers(int pageNo, int pageSize)
        {
           var lst =  _userService.GetUsers(pageNo, pageSize);
           
            return Ok(lst);

        }

        [HttpGet("{id}")]
        public IActionResult GetUsersById(int id)
        {

            var user = _userService.GetUserById(id);

            if(!user.IsSuccess)
            {
                return NotFound(new
                {
                    Status = "failed",
                    message = user.Message,
                    StatusCode = "404",
                });
            }
             return Ok(user);
              
        }


        [HttpPost]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            var model = _userService.InsertUser(user);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {

            var model = _userService.UpdateUser(id, user);
            if (!model.IsSuccess)
            {
                return NotFound(new
                {
                    Status = "failed",
                    message = model.Message,
                    StatusCode = "404",
                });
            }

            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var model = _userService.DeleteUser(id);
            if (!model.IsSuccess)
            {
                return NotFound(new
                {
                    Status = "failed",
                    message = model.Message,
                    StatusCode = "404",
                });
            }

            return Ok(model);

        }

    }
}
