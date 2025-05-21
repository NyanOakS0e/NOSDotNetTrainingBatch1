using System.Linq;
using API_Start.Models;
using Microsoft.Data.SqlClient;
using SQL_Services_Shared;

namespace API_Start.Services
{
    //Business Logic Layer + Data Access Layer

    //Request => requestModel
    //Response => responseModel
    public class UserService
    {
        private readonly DapperService _dbs;
        private readonly ApiDbContext _appDbContext;

        public UserService(DapperService dbs, ApiDbContext appDbContext)
        {
            _dbs = dbs;
            _appDbContext = appDbContext;
        }



        //public UserService()
        //{
        //    _dbs = new DapperService(new SqlConnectionStringBuilder()
        //    {
        //        DataSource = ".",
        //        InitialCatalog = "NOSDotNetTrainingBatch1",
        //        UserID = "sa",
        //        Password = "sasa@123",
        //        TrustServerCertificate = true,
        //    });

        //    _appDbContext = new ApiDbContext();
        //}
        public ResponseModel GetUsers(int pageNo = 1, int pageSize = 5)
        {
            //var lst = _dbs.Query<UserModel>("SELECT * FROM dbo.Users");

            var lst = _appDbContext.Users.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();

            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = lst,
            };
            
            return model;
        }


        public ResponseModel GetUserById(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Data = null!,
                }; ;
            }
            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = user,
            };

            return model;
        }



        public ResponseModel InsertUser(UserModel requestModel)
        {
            var addedUser = _appDbContext.Users.Add(new UserModel()
            {
                Name = requestModel.Name,
                Email = requestModel.Email
            });

            var lastAddedUser = new
            {
                id = requestModel.Id, //id will be zero because it will be default value at this stage
                name = requestModel.Name,
                email = requestModel.Email,

            };

            int count = _appDbContext.SaveChanges();

            var model = new ResponseModel
            {
                IsSuccess = true,
                Message = "Success",
                Data = lastAddedUser,
            };

            return model;
        }


        public ResponseModel UpdateUser(int id, UserModel requestModel)
        {

            UserModel findedUser = _appDbContext.Users.FirstOrDefault(x => x.Id == id)!;

            if (!requestModel.Name.IsNullOrEmptyV2() && !requestModel.Name.IsNullOrEmptyV2())
            {
                findedUser.Name = requestModel.Name;

            }
            if (!requestModel.Email.IsNullOrEmptyV2() && !requestModel.Email.IsNullOrEmptyV2())
            {
                findedUser.Email = requestModel.Email;
            }

            if (requestModel.Name.IsNullOrEmptyV2() && requestModel.Email.IsNullOrEmptyV2())
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Data = null!,
                };
            }

            _appDbContext.SaveChanges();

            var data = new UserModel
            {
                Id = requestModel.Id,
                Name = requestModel.Name,
                Email = requestModel.Email,
            };

            var model = new ResponseModel
            {
                IsSuccess = true,
                Data = data,
                Message = "User updated successfully",
            };

            return model;
        }


        public ResponseModel DeleteUser(int id)
        {
            var user = _appDbContext.Users.FirstOrDefault(x => x.Id == id);


            if(user == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Data = null!,
                };
            }

            _appDbContext.Users.Remove(user!);

            _appDbContext.SaveChanges();

            var deletedData = new
            {
                ID = user.Id,
                Name = user.Name,
                Email = user.Email,
            };
            var model = new ResponseModel
            {
               IsSuccess = true,
               Data = deletedData,
                Message = "User deleted successfully",
            };
            return model;
        }
    }
}
