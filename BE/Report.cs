using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Report
    {
        [Key]
        [Column(Order = 1)]
        public int FallId { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime DateRep { get; set; }

        public String NameReporter { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public int BoomsN { get; set; }
        public int Intensity { get; set; }
        //public double LongRep { get; set; }
        //public double LatRep { get; set; }

        private Coordinate coordinateR;

        public Coordinate CoordinateR
        {
            get { return coordinateR; }
            set { coordinateR = value; }
        }

        public Report(int fallId, DateTime date, String nameReporter, String address, String city, int boomsN, int intensity, Coordinate coordinateR)
        {
            FallId = fallId;
            DateRep = date;
            NameReporter = nameReporter;
            Address = address;
            City = city;
            BoomsN = boomsN;
            Intensity = intensity;
            CoordinateR = coordinateR;
        }

        public Report()
        {
            FallId = 0;
            DateRep = DateTime.Now;
            NameReporter = "Krinitsi 105";
            Address = "";
            BoomsN = 1;
            Intensity = 1;
            CoordinateR = new Coordinate(32.088139, 34.820330);
            City = "Ramat Gan";



        }
    }
}
   