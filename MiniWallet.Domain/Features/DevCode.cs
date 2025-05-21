using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniWallet.Database.Models;

namespace MiniWallet.Domain.Features
{
    public static class DevCode
    {
        
        public static bool isNullOrEmptyV2(this string str)
        {
            if(string.IsNullOrEmpty(str) || string.IsNullOrEmpty(str.Trim()))
            {
                return true;
            }
            else
            {
                return false;
            } 
        }

        public static bool isWalletPhoneNumberExist(AppDbContext _dbContext, string? phoneNumber)
        {
            if(_dbContext.TblWallets.FirstOrDefault(x => x.MobileNo == phoneNumber) is not null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
