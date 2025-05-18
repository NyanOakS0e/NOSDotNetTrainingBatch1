using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SQL_Services_Shared
{
    public static class DevCode
    {
        public static bool IsNullOrEmptyV2(this string? str)
        {
            return str != null && !string.IsNullOrEmpty(str.Trim());
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
