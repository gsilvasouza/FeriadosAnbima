using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FeriadoAnbima.utils
{
    public abstract class ConvertUtils
    {
        public static DateTime ConvertDate(string data)
        {
            int index = data.LastIndexOf("/") + 1;
            string data2 = data.Insert(index, "20");
            return Convert.ToDateTime(data2);
        }
    }
}
