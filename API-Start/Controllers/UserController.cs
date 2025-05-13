using API_Start.Models;
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

        private readonly DapperService _dbs;
        ApiDbContext _appDbContext;


        public UserController()
        {
            _dbs = new DapperService(new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "NOSDotNetTrainingBatch1",
                UserID = "sa",
                Password = "sasa@123",
                TrustServerCertificate = true,
            });

            _appDbContext = new ApiDbContext();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {

            var lst = _dbs.Query<UserModel>("SELECT * FROM dbo.Users");

            return Ok(lst);

        }

        [HttpPost]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            var addedUser = _appDbContext.Users.Add(new UserModel()
            {
                Name = user.Name,
                Email = user.Email
            });

            var lastAddedUser = new
            {
                id = user.Id, //id will be zero because it will be default value at this stage
                name = user.Name,
                email = user.Email,

            };

            int count = _appDbContext.SaveChanges();

            object returnValue = new
            {
                Status = "success",
                message = "Insert Successful",
                effected_count = count,
                data = lastAddedUser,
                StatusCode = "200",
            };

            return Ok(returnValue);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            UserModel findedUser = _appDbContext.Users.FirstOrDefault(x => x.Id == id)!;

            findedUser.Name = user.Name;
            findedUser.Email = user.Email;

            _appDbContext.SaveChanges();

            var data = new
            {
                Name = user.Name,
                Email = user.Email,
            };

            object returnValue = new
            {
                Status = "success",
                message = "Update Successful",
                data = data,
                StatusCode = "200",
            };

            return Ok(returnValue);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Id == id);

            _appDbContext.Users.Remove(user!);

            _appDbContext.SaveChanges();

            var deletedData = new
            {
                ID = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
            object returnValue = new
            {
                Status = "success",
                message = "Delete Successful",
                data = deletedData,
                StatusCode = "200",
            };
            return Ok(returnValue);
        }
    }
}
