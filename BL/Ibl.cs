using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
   public interface Ibl
    {
        void AddFalling(Falling f);
        void AddReport(Report r);
        List<Falling> GetAllFalling();
        List<Report> GetAllReport();
        List<Coordinate> KMeansG(int id);
        DateTime ChangeDateToNumber(string Myd);
        Coordinate PhotoToC(string path);
        List<Coordinate> TodayKMeansG();
        List<Coordinate> KMeansGByDate(DateTime dt);
        List<Coordinate> FallingByDate(DateTime dt);
        List<Coordinate> TodayFalling();
        List<Coordinate> GetFallingsByDateOrCity( String date);
        List<double> writeByDay(int num, int d, int m);
        double todayC(int num);
        List<double> MonthBydayC(int num,int m);
        List<double> YearByMonthC(int num);
        
    }
}
