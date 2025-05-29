using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.WithDrawServices
{
    public class WithdrawResponseModel : ResponseModel
    {
        public string? MobileNumber { get; set; }
        public decimal? OldAmount { get; set; }
        public decimal? LatestAmount { get; set; }
        public string? TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
