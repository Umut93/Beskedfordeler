using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.eDoc.SAPA.BLL
{
    public class CommonHelper
    {
        public static string StringToUTF8(string toUTF8)
        {
            if (!string.IsNullOrEmpty(toUTF8))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(toUTF8);
                return Encoding.UTF8.GetString(bytes);
            }
            else
            {
                return string.Empty;
            }
            
        }
    }
}
