using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWallet.Domain.Features.TransferServices
{
    public class TransferRequestModel
    {
        public string? FromMobileNumber { get; set; }
        public string? ToMobileNumber { get; set; }
        public decimal? amount { get; set; }

    }
}
