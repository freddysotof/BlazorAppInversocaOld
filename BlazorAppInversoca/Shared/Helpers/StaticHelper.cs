using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorAppInversoca.Shared.Helpers
{
    public static class StaticHelper
    {
        public static string FirstLetterCapital(string str)
        {
            var tmp = str.Split(' ');
            str = "";
            if (tmp.Count() > 1)
            {
                for (int i = 0; i < tmp.Count(); i++)
                {
                    if (tmp[i] != null && tmp[i] != "")
                    {
                        tmp[i] = tmp[i].ToLower();
                        tmp[i] = tmp[i].Trim();
                        str = str + " " + Char.ToUpper(tmp[i][0]) + tmp[i].Remove(0, 1);
                    }
                }
            }
            else
            {
                tmp[0] = tmp[0].ToLower();
                tmp[0] = tmp[0].Trim();
                str = Char.ToUpper(tmp[0][0]) + tmp[0].Remove(0, 1);
            }
            return str.Trim();
        }
    }
}
