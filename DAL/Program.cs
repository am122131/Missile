using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var v in FactoryDal.GetDal().GetAllReport().ToArray())
                if (v.Intensity < 0 || v.BoomsN < 0)
                    FactoryDal.GetDal().delReport(v);
        }
    }
}
