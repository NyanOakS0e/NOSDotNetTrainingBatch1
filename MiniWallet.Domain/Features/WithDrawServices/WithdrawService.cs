using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniWallet.Database.Models;
using MiniWallet.Domain.Features.DepositServices;

namespace MiniWallet.Domain.Features.WithDrawServices
{
    public class WithdrawService
    {

        private readonly AppDbContext _dbContext;

        public WithdrawService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WithdrawResponseModel Deposit(WithdrawRequestModel request)

        {
            WithdrawResponseModel response = new WithdrawResponseModel();
            var item = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.MobileNo)!;


            #region Mobile Number validation
            if (request.MobileNo!.isNullOrEmptyV2())
            {
                response = new WithdrawResponseModel()
                {
                    isSuccess = false,
                    message = "Mobile number is required",
                };
                goto Result;
            }
            #endregion

            #region Amount validation
            if (request.Amount <= 0)
            {
                response = new WithdrawResponseModel()
                {
                    isSuccess = false,
                    message = "Amount should be greater than 0",
                };
                goto Result;
            }
            #endregion

            #region Phone Number Exist validation

            if (!DevCode.isWalletPhoneNumberExist(_dbContext, request.MobileNo))
            {
                response = new WithdrawResponseModel()
                {
                    isSuccess = false,
                    message = "Phone Number does not exist",
                };
                goto Result;
            }

            if(request.Amount > item.Balance)
            {
                response = new WithdrawResponseModel()
                {
                    isSuccess = false,
                    message = "Insufficient balance",
                };
                goto Result;
            }
            #endregion

            else
            {

                var oldAmount = item.Balance;

                item.Balance -= request.Amount;

                _dbContext.SaveChanges();

                _dbContext.TblWalletHistories.Add(new TblWalletHistory()
                {
                    MobileNo = request.MobileNo!,
                    TransactionType = "Withdraw",
                    Amount = request.Amount,
                    DateTime = DateTime.Now
                });

                _dbContext.SaveChanges();

                response = new WithdrawResponseModel()
                {
                    isSuccess = true,
                    message = "Withdraw successful",
                    MobileNumber = request.MobileNo,
                    OldAmount = oldAmount,
                    LatestAmount = item.Balance,
                    TransactionType = "Withdraw",
                    TransactionDate = DateTime.Now
                };

                goto Result;
            }


        Result:

            return response;

        }
    }
}
