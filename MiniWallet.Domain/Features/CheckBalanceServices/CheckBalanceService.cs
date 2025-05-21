using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;

namespace MiniWallet.Domain.Features.CheckBalanceServices
{
    public class CheckBalanceService
    {
        private readonly AppDbContext _dbContext;
        public CheckBalanceService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CheckBalanceResponseModel CheckBalance(CheckBalanceRequestModel request)
        {
            CheckBalanceResponseModel response;


            if (!DevCode.isWalletPhoneNumberExist(_dbContext, request.MobileNumber))
            {
                response = new CheckBalanceResponseModel
                {
                    isSuccess = false,
                    message = "Wallet not found",
                    Balance = 0,
                    MobileNumber = request.MobileNumber,
                    TransactionHistoryList = null
                };

                goto result;


            }
            else
            {
                var balance = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.MobileNumber)?.Balance;
                var walletHistory = _dbContext.TblTransactions
                    .Where
                    (
                      (
                          x => x.FromMobileNo == request.MobileNumber ||
                          x.ToMobileNo == request.MobileNumber
                       )
                     )
                    .OrderByDescending(x => x.TransactionDate)
                    .Take(5)
                    .ToList();

                var responseable = walletHistory.Select(x => new CheckBalanceTransactionModel()
                {
                    TransactionNo = x.TransactionNo,
                    FromMobileNo = x.FromMobileNo,
                    ToMobileNo = x.ToMobileNo,
                    Amount = x.Amount,
                    TransactionDate = x.TransactionDate
                }).ToList();
                {


                    response = new CheckBalanceResponseModel()
                    {
                        isSuccess = true,
                        message = "Wallet found",
                        Balance = balance,
                        MobileNumber = request.MobileNumber,
                        TransactionHistoryList = responseable
                    };

                    goto result;

                }
            }
        result:

            return response;
        }
    }
}

