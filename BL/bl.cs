using GMap.NET;
using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
namespace BL
{
    class bl
    {
        //public static double[] getLongLatOfAddress(string address)
        //{
        //    var locationService = new GoogleLocationService("AIzaSyAdFS6LDKmiZjFoQt3HYXc09BDfrUak5oU‏");
        //    var point = locationService.GetLatLongFromAddress(address);
        //    var s = locationService.GetRegionFromLatLong(32.056124, 34.810105);
        //    Console.WriteLine(s);
        //    return new double[2] { point.Latitude, point.Longitude };
        //}
        static string baseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";

        static void Main(string[] args)
        {
            var p = new PointLatLng(21.254821755335, 78.9903259277344);
            //   var l = GetAddress(21.254821755335, 78.9903259277344);
            // foreach (var v in l)
            //    Console.WriteLine(v);

        }
      

    }
}
//Console.WriteLine(longLat[0]+" "+longLat[1]);
//Coordinate coo = new Geocoder().Geocode("Bnei Brak", "Shadal 2");
//Console.WriteLine(coo.Latitude+" "+ coo.Longitude);
// var v = FactoryBl.GetBL().PhotoToC("C://Users//Havlin//Downloads//IMG_20190830_010731.jpg");
//  FactoryBl.GetBL().AddReport(new Report(9, DateTime.Now, "d", "Daniel 2", "Ramat Gan", 1, 1, new Coordinate()));

//            var gps = ImageMetadataReader.ReadMetadata("C://Users//Havlin//Downloads//IMG_20190830_010731.jpg")
//                             .OfType<GpsDirectory>()
//                             .FirstOrDefault();

//            var location = gps.GetGeoLocation();
//            var latitude = location.Latitude;
//            var longitude = location.Longitude;

//            var directories = ImageMetadataReader.ReadMetadata("C://Users//Havlin//Downloads//IMG_20190830_010731.jpg");

//            // Find the so-called Exif "SubIFD" (which may be null)
//            var subIfdDirectory = directories.OfType<ExifSubIfdDirectory>().FirstOrDefault();

//            // Read the DateTime tag value
//            var dateTime = subIfdDirectory?.GetDateTime(ExifDirectoryBase.TagDateTimeOriginal);
//            Coordinate c = new Coordinate(latitude, longitude);


//            int d = 0;
//            int m = 0;
//            int y = 2000;


//            d = int.Parse(dateTime.ToString()[0].ToString()) * 10 + int.Parse(dateTime.ToString()[1].ToString());
//            if (dateTime.ToString().Contains("Jan"))
//                m = 1;
//            else if (dateTime.ToString().Contains("Feb"))
//                m = 2;
//            else if (dateTime.ToString().Contains("Mar"))
//                m = 3;
//            else if (dateTime.ToString().Contains("Apr"))
//                m = 4;
//            else if (dateTime.ToString().Contains("May"))
//                m = 5;
//            else if (dateTime.ToString().Contains("Jun"))
//                m = 6;
//            else if (dateTime.ToString().Contains("Jul"))
//                m = 7;
//            else if (dateTime.ToString().Contains("Aug"))
//                m = 8;
//            else if (dateTime.ToString().Contains("Sep"))
//                m = 9;
//            else if (dateTime.ToString().Contains("Oct"))
//                m = 10;
//            else if (dateTime.ToString().Contains("Nov"))
//                m = 11;
//            else
//                m = 12;

//            y = y + int.Parse(dateTime.ToString()[7].ToString()) * 10 + int.Parse(dateTime.ToString()[8].ToString());

//            int h;
//            int min;
//            int s;
//            h = int.Parse(dateTime.ToString()[10].ToString()) * 10 + int.Parse(dateTime.ToString()[11].ToString());
//            min = int.Parse(dateTime.ToString()[13].ToString()) * 10 + int.Parse(dateTime.ToString()[14].ToString());
//            s = int.Parse(dateTime.ToString()[16].ToString()) * 10 + int.Parse(dateTime.ToString()[17].ToString());
//            DateTime Mydate = new DateTime(y, m, d, h, min, s);
//            Console.WriteLine(Mydate.ToShortDateString() + " " + Mydate.ToShortTimeString());




//            getLongLatOfAddress("HaHavatselet 19-9 Tel Aviv - Yafo");




//            for (int i = -999999; i < 999999999;)
//                i++;
//            for (int i = -999999; i < 999999999;)
//                i++;

//            for (int i = -999999; i < 999999999;)
//                i++;
//            for (int i = -999999; i < 999999999;)
//                i++;
//            for (int i = -999999; i < 999999999;)
//                i++;
//            //  Console.WriteLine(new Geocoder().GetDistanceBetweenPoints(coo, new Coordinate(32, 12)));

//        }




//        public static double[] getLongLatOfAddress2(string address)
//        {
//            var locationService = new GoogleLocationService();
//            var point = locationService.GetLatLongFromAddress(address);
//            return new double[2] { point.Latitude, point.Longitude };
//        }


//    }
//}




