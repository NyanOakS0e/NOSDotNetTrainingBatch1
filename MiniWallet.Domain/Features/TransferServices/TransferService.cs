using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;
using MiniWallet.Domain.Features.WithDrawServices;

namespace MiniWallet.Domain.Features.TransferServices
{
    public class TransferService
    {
        private readonly AppDbContext _dbContext;

        public TransferService(AppDbContext context)
        {
            _dbContext = context;
        }

        public TransferResponseModel Transfer(TransferRequestModel request)
        {
            TransferResponseModel response;

            var fromWallet = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.FromMobileNumber)!;
            var toWallet = _dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == request.ToMobileNumber)!;


            if (request.FromMobileNumber.isNullOrEmptyV2() || request.ToMobileNumber.isNullOrEmptyV2())
            {
                response = new TransferResponseModel()
                {
                    isSuccess = false,
                    message = "Mobile number fields are required",
                };
                goto Result;
            }

            if(!DevCode.isWalletPhoneNumberExist(_dbContext, request.FromMobileNumber))
            {
                response = new TransferResponseModel()
                {
                    isSuccess = false,
                    message = "From mobile number does not exist",
                };
                goto Result;
            }

            if (!DevCode.isWalletPhoneNumberExist(_dbContext, request.ToMobileNumber))
            {
                response = new TransferResponseModel()
                {
                    isSuccess = false,
                    message = "To mobile number does not exist",
                };
                goto Result;
            }


            if(request.amount <= 0)
            {
                response = new TransferResponseModel()
                {
                    isSuccess = false,
                    message = "Amount must be greater than 0",
                };
                goto Result;
            }

            if(request.amount > fromWallet.Balance)
            {
                response = new TransferResponseModel()
                {
                    isSuccess = false,
                    message = "Insufficient balance",
                };
                goto Result;
            }

            fromWallet.Balance -= request.amount;
            toWallet.Balance += request.amount;
            var guid = Guid.NewGuid().ToString();
            _dbContext.TblTransactions.Add(new TblTransaction()
            {
                TransactionId = guid,
                TransactionNo = new byte[1],
                FromMobileNo = request.FromMobileNumber,
                ToMobileNo = request.ToMobileNumber,
                Amount = request.amount,
                TransactionDate = DateTime.Now,
            });

            _dbContext.SaveChanges();

            response = new TransferResponseModel()
            {
                isSuccess = true,
                message = "Transfer successful",
                FromMobileNumber = request.FromMobileNumber,
                FromUserName = fromWallet.FullName,
                ToUserName = toWallet.FullName,
                ToMobileNumber = request.ToMobileNumber,
                amount = request.amount,
            };

        Result:

            return response;
        }
    }
}
