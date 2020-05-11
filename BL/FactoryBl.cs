using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class FactoryBl
    {
        static Ibl Ibl = null;
        public static List<BE.Falling> GFallings = null;
        public static Ibl GetBL()
        {
            if (Ibl == null)
            {
                Ibl = new Bl_imp();
                GFallings = new List<BE.Falling>();

            }
            return Ibl;
        }
    }
}
