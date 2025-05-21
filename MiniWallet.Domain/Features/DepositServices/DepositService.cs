using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;

namespace MiniWallet.Domain.Features.DepositServices
{
    
    public class DepositService
    {
        private readonly AppDbContext _dbContext;

        public DepositService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public ResponseDepositModel Deposit(RequestDepositModel request)
        {
            ResponseDepositModel response = new ResponseDepositModel();


            #region Mobile Number validation
            if (request.MobileNumber!.isNullOrEmptyV2())
            {
                response = new ResponseDepositModel()
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
                response = new ResponseDepositModel()
                {
                    isSuccess = false,
                    message = "Amount should be greater than 0",
                };
                goto Result;
            }
            #endregion

            #region Phone Number Exist validation

            if (!DevCode.isWalletPhoneNumberExist(_dbContext, request.MobileNumber))
            {
                response = new ResponseDepositModel()
                {
                    isSuccess = false,
                    message = "Phone Number does not exist",
                };
                goto Result;
            }
            #endregion

            else
            {
                var item = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.MobileNumber)!;

                var oldAmount = item.Balance;

                item.Balance += request.Amount;

                _dbContext.SaveChanges();

                _dbContext.TblWalletHistories.Add(new TblWalletHistory()
                {
                    MobileNo = request.MobileNumber!,
                    TransactionType = "Deposit",
                    Amount = request.Amount,
                    DateTime = DateTime.Now
                });

                _dbContext.SaveChanges();

                response = new ResponseDepositModel()
                {
                    isSuccess = true,
                    message = "Deposit successful",
                    MobileNumber = request.MobileNumber,
                    OldAmount = oldAmount,
                    LatestAmount = item.Balance,
                    TransactionType = "Deposit",
                    TransactionDate = DateTime.Now
                };

                goto Result;
            }


            Result:

            return response;

        }
    }
}
