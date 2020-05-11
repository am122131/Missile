using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FactoryDal
    {
        static Idal Idal = null;
        public static Idal GetDal()
        {
            if (Idal == null)
            {
                Idal = new Dal_imp();
            }
            return Idal;
        }
    }
}
