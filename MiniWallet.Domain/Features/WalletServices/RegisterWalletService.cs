using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;

namespace MiniWallet.Domain.Features.WalletServices
{
    public class RegisterWalletService
    {
        private readonly AppDbContext _dbContext;
        
        public RegisterWalletService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public RegisterWalletResponseModel RegisterWallet(RegisterWalletRequestModel request)
        {
            RegisterWalletResponseModel response = new RegisterWalletResponseModel();

            if(request.MobileNumber!.isNullOrEmptyV2())
            {
                response = new RegisterWalletResponseModel()
                {
                   isSuccess = false,
                   message = "Mobile number is required",
                };
                goto Result;
            }

            if (request.WalletUserName!.isNullOrEmptyV2())
            {
                response = new RegisterWalletResponseModel()
                {
                    isSuccess = false,
                    message = "User Name is required",
                };
                goto Result;
            }
            if(DevCode.isWalletPhoneNumberExist(_dbContext, request.MobileNumber))
            {
                response = new RegisterWalletResponseModel()
                {
                    isSuccess = false,
                    message = "Phone Number already exists",
                };
                goto Result;
            }

            else
            {
                _dbContext.TblWallets.Add(new TblWallet()
                {
                    WalletUserName = request.WalletUserName,
                    FullName = request.FullName,
                    MobileNo = request.MobileNumber,
                    Balance = 0,
                });

                _dbContext.SaveChanges();

                response = new RegisterWalletResponseModel()
                {
                    isSuccess = true,
                    message = "Wallet registered successfully",
                    WalletId = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.MobileNumber).WalletId,
                    WalletUserName = request.WalletUserName,
                    FullName = request.FullName,
                    MobileNumber = request.MobileNumber
                };
                goto Result;
            }
               

        Result:
            return response;
        }
    }
}
