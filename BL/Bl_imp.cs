using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using MetadataExtractor;
using MetadataExtractor.Formats.Exif;
namespace BL
{
    class Bl_imp : Ibl
    {
        Geocoder g = new Geocoder();
        List<Falling> list = new List<Falling>();
        public Bl_imp()
        {
           
            foreach (var v in FactoryDal.GetDal().GetAllReport())
            {
                int flag = 0;
                foreach(var h in list)
                if (v.DateRep.Year-h.DateFalling.Year==0&& v.DateRep.Month - h.DateFalling.Month==0&& v.DateRep.Day - h.DateFalling.Day==0&&v.DateRep.Hour-h.DateFalling.Hour==0)
                        if(v.DateRep.Minute-h.DateFalling.Minute<5&& v.DateRep.Minute - h.DateFalling.Minute>-5)
                    if (g.GetDistanceBetweenPoints(h.CoordinateF, v.CoordinateR) < 2)
                    {
                        
                        flag = 1;
                    }

                //if it dosen't find an optenial fall it creat a new one with the details of the first report
                if (flag == 0)
                {
                    Falling f = new Falling(v.City, v.Address, v.DateRep, v.CoordinateR);
                   list.Add(f);
                    


                }
            }
        }
        public List<Coordinate> GetFallingsByDateOrCity(String date)
        {

            List<Coordinate> reportL = new List<Coordinate>();
            
                if (date[3] == 0 || date[3] == 1)
                {
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {

                        if (v.DateFalling.Year == 2000 + int.Parse(date[6].ToString()) * 10 + int.Parse(date[7].ToString()))
                            if (v.DateFalling.Month == int.Parse(date[3].ToString()) * 10 + int.Parse(date[4].ToString()))
                                if (v.DateFalling.Day == int.Parse(date[0].ToString()) * 10 + int.Parse(date[1].ToString()))

                                    reportL.Add(new Coordinate(v.CoordinateF.Latitude, v.CoordinateF.Longitude));
                    }
                }
                else
                {
                    DateTime my = FactoryBl.GetBL().ChangeDateToNumber(date);
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {

                        if (v.DateFalling.Year == my.Year)
                            if (v.DateFalling.Month == my.Month)
                                if (v.DateFalling.Day == my.Day)
                                    reportL.Add(new Coordinate(v.CoordinateF.Latitude, v.CoordinateF.Longitude));
                    }

                }
                return reportL;// = reportL;
            }

        
       public List<Coordinate>KMeansG(int id)
        {
            List<Coordinate> CoorL = new List<Coordinate>();
            List<Report> list = new List<Report>();
            int mone = 0;
            int n = 0;
            foreach(var v in GetAllReport().ToArray())
                if(v.FallId==id)
                {
                    list.Add(v);
                    mone += v.BoomsN;
                    n++;
                }
            if (n == 0)
                n++;
            KMeans km = new KMeans(list, mone / n);
            foreach (var l in km.K_Means())
                CoorL.Add(new Coordinate(l.Latitude, l.Longitude));
            return CoorL;

            
        }
        public List<Coordinate> TodayKMeansG()
        {
            List<int> Ids = new List<int>();
            List<Coordinate> CoorL = new List<Coordinate>();
            List<Report> list = new List<Report>();
            List<Report> litleL = new List<Report>();
            int mone = 0;
            int n = 0;

            foreach (var v in GetAllReport().ToArray())
            {
                if(v.DateRep.ToShortDateString()==DateTime.Now.ToShortDateString())
                Ids.Add(v.FallId);
            }
          for(int i = 0; i < Ids.Count(); i++)
            {
                for (int j = 0; j < Ids.Count()-1; j++)
                    if(Ids[j+1]<Ids[j])
                    {
                        int x = Ids[j];
                        Ids[j] = Ids[j + 1];
                        Ids[j + 1] = x;

                    }
            }
            List<int> MyIds = new List<int>();
            if(Ids.Count()!=0)
            MyIds.Add(Ids[0]);
            for (int i = 1; i < Ids.Count(); i++)
            {
                if (Ids[i] != Ids[i - 1])
                    MyIds.Add(Ids[i]);
            }
            foreach (var v in MyIds)
                foreach (var l in KMeansG(v).ToArray())
                    CoorL.Add(l);
            return CoorL;



        }



        public List<Coordinate> KMeansGByDate(DateTime dt)
        {
            List<int> Ids = new List<int>();
            List<Coordinate> CoorL = new List<Coordinate>();
            List<Report> list = new List<Report>();
            List<Report> litleL = new List<Report>();
            int mone = 0;
            int n = 0;

            foreach (var v in GetAllReport().ToArray())
            {
                if (v.DateRep.ToShortDateString() == dt.ToShortDateString())
                    Ids.Add(v.FallId);
            }
            for (int i = 0; i < Ids.Count(); i++)
            {
                for (int j = 0; j < Ids.Count() - 1; j++)
                    if (Ids[j + 1] < Ids[j])
                    {
                        int x = Ids[j];
                        Ids[j] = Ids[j + 1];
                        Ids[j + 1] = x;

                    }
            }
            List<int> MyIds = new List<int>();
            MyIds.Add(Ids[0]);
            for (int i = 1; i < Ids.Count(); i++)
            {
                if (Ids[i] != Ids[i - 1])
                    MyIds.Add(Ids[i]);
            }
            foreach (var v in MyIds)
                foreach (var l in KMeansG(v).ToArray())
                    CoorL.Add(l);
            return CoorL;



        }



        public DateTime ChangeDateToNumber(string Myd)
        
{
           
            int y, d, m;
            m = 0;
            d = 0;
            y = 0;
              d = int.Parse(Myd[0].ToString()) * 10 + int.Parse((Myd[1].ToString()));
            //m = int.Parse(this.Date.Text[3].ToString()) * 10 + int.Parse(this.Date.Text[4].ToString());
            if (Myd.Contains("Jan"))
                m = 1;
            else if(Myd.Contains("Feb"))
                m = 2;
            else if(Myd.Contains("Mar"))
                m = 3;
            else if (Myd.Contains("Apr"))
                m = 4;
            else if (Myd.Contains("May"))
                m = 5;
            else if (Myd.Contains("Jun"))
                m = 6;
            else if (Myd.Contains("Jul"))
                m = 7;
            else if (Myd.Contains("Aug"))
                m = 8;
            else if (Myd.Contains("Sep"))
                m = 9;
            else if (Myd.Contains("Oct"))
                m = 10;
            else if (Myd.Contains("Nov"))
                m = 11;
            else 
                m = 12;
            
            y = int.Parse(Myd[7].ToString()) * 10 + int.Parse(Myd[8].ToString());
            y = y + 2000;
            return new DateTime(y,m,d);

        }

        public List<Coordinate>DayKMG(int d,int m){

            List<int> Ids = new List<int>();
        List<Coordinate> CoorL = new List<Coordinate>();
        List<Report> list = new List<Report>();
        List<Report> litleL = new List<Report>();
        int mone = 0;
        int n = 0;

            foreach (var v in GetAllReport().ToArray())
            {
                if(v.DateRep.Day==d&&v.DateRep.Month==m)
                Ids.Add(v.FallId);
            }
          for(int i = 0; i<Ids.Count(); i++)
            {
                for (int j = 0; j<Ids.Count()-1; j++)
                    if(Ids[j + 1]<Ids[j])
                    {
                        int x = Ids[j];
    Ids[j] = Ids[j + 1];
                        Ids[j + 1] = x;

                    }
            }
            List<int> MyIds = new List<int>();
            if (Ids.Count()!=0)
            {
                MyIds.Add(Ids[0]);
                for (int i = 1; i < Ids.Count(); i++)
                {
                    if (Ids[i] != Ids[i - 1])
                        MyIds.Add(Ids[i]);
                }
                foreach (var v in MyIds)
                    foreach (var l in KMeansG(v).ToArray())
                        CoorL.Add(l);
            }
            return CoorL;



        }
        public List< double> writeByDay(int num,int d,int m)
        {
            List<double> ans = new List<double>();
           
            int mone = 0;
            int count = 0;
            List<Falling> Flist = new List<Falling>();
           
            foreach (var f in GetAllFalling().ToArray())
                if (f.DateFalling.Day == d)
                    Flist.Add(f);
            var KMlist=DayKMG(d,m);
            count = Flist.Count();
            int flag = 0;
            foreach (var v in Flist) {
                flag = 0;
                foreach (var k in KMlist)
                {
                    if (flag == 0)
                        if (g.GetDistanceBetweenPoints(v.CoordinateF, k) <= num)
                        {
                            mone++;
                            flag++;
                        }
                }
                }
            ans.Add(mone);
            ans.Add(count);

            return ans;
        }
        public double todayC(int num)
        {
            var v = writeByDay(num, DateTime.Now.Day, DateTime.Now.Month);

            return v[0] / v[1];
        }
       public List<double> MonthBydayC(int num, int m)
        {
            List<double> MyList = new List<double>();
            MyList.Add(0);
            if(m==DateTime.Now.Month)
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
              var v=  writeByDay(num, i, DateTime.Now.Month);
                    if (v[1] != 0)
                        MyList.Add(v[0]*100 / v[1]);
                    else
                        MyList.Add(0);
                }
            else
                for (int i = 1; i <= 28; i++)
                {
                    var v = writeByDay(num, i,m);
                    if (v[1] != 0)
                        MyList.Add(v[0]*100 / v[1]);
                    else
                        MyList.Add(0);
                }
            return MyList;
        }
        public List<double> YearByMonthC(int num)
        {
            
            double m = 0;
            double c = 0;
            List<double> MyList = new List<double>();
            MyList.Add(0);
            for (int i = 1; i < DateTime.Now.Month; i++) {
                m = 0;
                c = 0;

                for (int j = 1; j < 30; j++)
                {
                    var v = writeByDay(num,j,i);
                    m = m + v[0];
                    c = c + v[1];
                                    }
                MyList.Add(m *100/ c);
            }
            for (int i = 0; i < 12 - DateTime.Now.Month+1; i++)
                MyList.Add(0);
            return MyList;
        }


        public void AddFalling(Falling f)
        {

            if (f.DateFalling > DateTime.Now)
                throw new Exception("The date is not valid");
            if(f.CoordinateF.Latitude!=0)
                Console.WriteLine("rfs");
            else
            f.CoordinateF = g.Geocode(f.City, f.Street);

            FactoryDal.GetDal().AddFalling(f);
        }

        public void AddReport(Report r)
        {
            if (r.DateRep > DateTime.Now)
                throw new Exception("The date is not valid");
            
            if (r.BoomsN <= 0)
                throw new Exception("The number is not valid");
         
            if (r.Intensity < 1 || r.Intensity > 10)
                throw new Exception("The Intensity is not valid");
            int flag = 0;
            var h = g.Geocode(r.City, r.Address);
            r.CoordinateR = new Coordinate(h.Latitude, h.Longitude);
            //Console.WriteLine(newReportFall.CoordinateR.Latitude + " " + newReportFall.CoordinateR.Longitude);


            foreach (var v in list)
            {

                if (r.DateRep.Year - v.DateFalling.Year == 0 && r.DateRep.Month - v.DateFalling.Month == 0 && r.DateRep.Day - v.DateFalling.Day == 0 && r.DateRep.Hour - v.DateFalling.Hour == 0)
                    if (r.DateRep.Minute - v.DateFalling.Minute < 5 && r.DateRep.Minute - v.DateFalling.Minute > -5)
                        if (g.GetDistanceBetweenPoints(r.CoordinateR, v.CoordinateF) < 500)
                    {
                        r.FallId = v.FallId;
                        flag = 1;
                    }

            }
            //if it dosen't find an optenial fall it creat a new one with the details of the first report
            if (flag == 0)
            {
                Falling f = new Falling( r.City, r.Address,r.DateRep, r.CoordinateR);
                list.Add(f);
                r.FallId = f.FallId;

            }
            
            FactoryDal.GetDal().AddReport(r);
        }

        public List<Falling> GetAllFalling()
        {
            List<Falling> MyList = new List<Falling>();
            foreach (var v in FactoryDal.GetDal().GetAllFalling())
                MyList.Add(v);
            return MyList;
        }
         public Coordinate PhotoToC(string path)
        {
            //   var dt = ImageMetadataReader.ReadMetadata(path).OfType<DateTime>().FirstOrDefault();
            //   var d = dt.Date;
            //   var t = dt.TimeOfDay; 
            string localPath = new Uri(path).LocalPath;
            var gps = ImageMetadataReader.ReadMetadata(localPath)
                             .OfType<GpsDirectory>()
                             .FirstOrDefault();

            var location = gps.GetGeoLocation();
          
            var latitude = location.Latitude;
            var longitude = location.Longitude;

            Coordinate c =new Coordinate(latitude,longitude);
            var directories = ImageMetadataReader.ReadMetadata(localPath);

            // Find the so-called Exif "SubIFD" (which may be null)
            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

            // Read the DateTime tag value
            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);

            int d = 0;
            int m = 0;
            int y = 2000;


            d = int.Parse(dateTime.ToString()[0].ToString()) * 10 + int.Parse(dateTime.ToString()[1].ToString());
            if (dateTime.ToString().Contains("Jan"))
                m = 1;
            else if (dateTime.ToString().Contains("Feb"))
                m = 2;
            else if (dateTime.ToString().Contains("Mar"))
                m = 3;
            else if (dateTime.ToString().Contains("Apr"))
                m = 4;
            else if (dateTime.ToString().Contains("May"))
                m = 5;
            else if (dateTime.ToString().Contains("Jun"))
                m = 6;
            else if (dateTime.ToString().Contains("Jul"))
                m = 7;
            else if (dateTime.ToString().Contains("Aug"))
                m = 8;
            else if (dateTime.ToString().Contains("Sep"))
                m = 9;
            else if (dateTime.ToString().Contains("Oct"))
                m = 10;
            else if (dateTime.ToString().Contains("Nov"))
                m = 11;
            else
                m = 12;

            y = y + int.Parse(dateTime.ToString()[7].ToString()) * 10 + int.Parse(dateTime.ToString()[8].ToString());

            int h;
            int min;
            int s;
            h = int.Parse(dateTime.ToString()[10].ToString()) * 10 + int.Parse(dateTime.ToString()[11].ToString());
            min = int.Parse(dateTime.ToString()[13].ToString()) * 10 + int.Parse(dateTime.ToString()[14].ToString());
            s = int.Parse(dateTime.ToString()[16].ToString()) * 10 + int.Parse(dateTime.ToString()[17].ToString());
            DateTime Mydate = new DateTime(y, m, d, h, min, s);

            // DateTime d =// ChangeDateToNumber(dateTime.ToString());
            AddFalling(new Falling(null, null, Mydate, c));
            return c;
        }
        public List<Report> GetAllReport()
        {

            List<Report> MyList = new List<Report>();
            foreach (var v in FactoryDal.GetDal().GetAllReport())
                MyList.Add(v);
            return MyList;
        }

        public List<Coordinate> TodayFalling()
        {
            List<Coordinate> myL = new List<Coordinate>();
            foreach (var v in FactoryBl.GetBL().GetAllFalling().ToArray())
                if (v.DateFalling.ToShortDateString() == DateTime.Now.ToShortDateString())
                    myL.Add(new Coordinate(v.CoordinateF.Latitude,v.CoordinateF.Longitude));
            return myL;
                }
        public List<Coordinate> FallingByDate(DateTime dt)
        {
            List<Coordinate> myL = new List<Coordinate>();
            foreach (var v in FactoryBl.GetBL().GetAllFalling().ToArray())
                if (v.DateFalling.ToShortDateString() == dt.ToShortDateString())
                    myL.Add(new Coordinate(v.CoordinateF.Latitude, v.CoordinateF.Longitude));
            return myL;
        }
    }
}
