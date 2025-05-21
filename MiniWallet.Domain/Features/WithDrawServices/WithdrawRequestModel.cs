using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.WithDrawServices
{
    public class WithdrawRequestModel
    {
        public string ? MobileNo { get; set; }
        public decimal Amount { get; set; }
    }
}
