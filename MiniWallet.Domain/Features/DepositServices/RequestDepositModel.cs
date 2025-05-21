using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.DepositServices
{
    public class RequestDepositModel
    {
        public string? MobileNumber { get; set; }

        public decimal Amount { get; set; }
    }
}
