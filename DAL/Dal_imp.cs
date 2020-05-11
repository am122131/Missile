using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class Dal_imp : Idal
    {

        public void AddFalling(Falling f)
        {
            using (var db = new MyContext())
            {


                db.Fallings.Add(f);
                db.SaveChanges();

            }
        }

        public void AddReport(Report r)
        {

            using (var db = new MyContext())
            {


                db.Reports.Add(r);
                db.SaveChanges();

            }
        }

        public List<Falling> GetAllFalling()
        {
            List<Falling> MyList = new List<Falling>();
            using (var db = new MyContext())
            {

                // Display all Blogs from the database
                //var query = from b in db.Fallings
                //            orderby b.FallId
                //            select b;
                foreach (var v in db.Fallings)
                    MyList.Add(v);
            }
            return MyList;
        }
        public void delReport(Report r)
        {
            using (var db = new MyContext())
            {
                db.Reports.Remove(r);
            }

            }
        public List<Report> GetAllReport()
        {
            List<Report> MyList = new List<Report>();
            using (var db = new MyContext())
            {

                // Display all Blogs from the database
                // var query = from b in db.Reports
                //            orderby b.FallId
                //             select b;
                foreach (var v in db.Reports)
                    if(v.Intensity>0&&v.BoomsN>0)
                    MyList.Add(v);
            }
            return MyList;
        }




















        #region

        public List<Report> GetAllSReport()
        {

            return reportList;
        }
        public List<Falling> GetAllSFalling()
        {

            return fallingtList;
        }
        public void AddSReport(Report r)
        {
            reportList.Add(r);
        }
        public void AddSFalling(Falling r)
        {
            fallingtList.Add(r);
        }
        List<Report> reportList = null;
        List<Falling> fallingtList = null;
        public Dal_imp()
        {
            fallingtList = new List<Falling>();
            fallingtList.Add(new Falling("Bnei Brak", "Sokolow 12 ", DateTime.Now, new Coordinate(32.087376, 34.833635)));
            reportList = new List<Report>();
            reportList.Add(new Report());
            reportList.Add(new Report(0, DateTime.Now, "netanel", "Derech Ben Gurion 50", "Bnei Brak", 2, 2, new Coordinate()));
            reportList.Add(new Report(0, new DateTime(2019, 8, 7, 11, 00, 22), "netanel", "Derech Ben Gurion 2", "Bnei Brak", 2, 2, new Coordinate()));
            reportList.Add(new Report(0, new DateTime(2019, 8, 9, 14, 50, 22), "netanel", "Derech Ben Gurion 4", "Bnei Brak", 2, 2, new Coordinate()));
            reportList.Add(new Report(0, new DateTime(2019, 8, 10, 10, 20, 22), "netanel", "Derech Ben Gurion 10", "Bnei Brak", 2, 2, new Coordinate()));






        }
        #endregion

    }
}
