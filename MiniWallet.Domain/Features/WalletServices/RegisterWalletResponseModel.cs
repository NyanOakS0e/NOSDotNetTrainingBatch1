using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.WalletServices
{
    public class RegisterWalletResponseModel : ResponseModel
    {
        public int WalletId { get; set; }
        public string? WalletUserName { get; set; }
        public string? FullName { get; set; }
        public string? MobileNumber { get; set; }
    }
}
