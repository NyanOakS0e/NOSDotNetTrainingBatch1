using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;

namespace MiniWallet.Domain.Features.CheckBalanceServices
{
    public class CheckBalanceResponseModel : ResponseModel
    {
        public decimal? Balance { get; set; }
        public string? MobileNumber { get; set; }

        public List<CheckBalanceTransactionModel>? TransactionHistoryList { get; set; }
    }


    public class CheckBalanceTransactionModel
    {
        public byte [] TransactionNo { get; set; } = null!;

        public string FromMobileNo { get; set; } = null!;

        public string ToMobileNo { get; set; } = null!;

        public decimal? Amount { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
