using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.WalletServices
{
    public class RegisterWalletRequestModel
    {
        public string? WalletUserName { get; set; }
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }


    }
}
