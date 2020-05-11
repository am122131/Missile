using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace DAL
{
  public  interface Idal
    {
        void AddFalling(Falling f);
        void AddReport(Report r);
        List<Falling> GetAllFalling();
        List<Report> GetAllReport();
        List<Report> GetAllSReport();
        void AddSReport(Report r);
        List<Falling> GetAllSFalling();
        void AddSFalling(Falling r);
        void delReport(Report r);
    }
}
