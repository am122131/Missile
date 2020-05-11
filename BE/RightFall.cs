using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class RightFall
    {
        static int x = 0;
        [Key]
        [Column(Order = 1)]
        public int FallId { get; set; }

        public String AddressFall { get; set; }
        private Coordinate coordinateF;
        public String CityFall { get; set; }
        public Coordinate CoordinateF
        {
            get { return coordinateF; }
            set { coordinateF = value; }
        }


        //public double LongFall { get; set; }
        //public double LatFall { get; set; }
        [Key]
        [Column(Order = 2)]
        public DateTime DateFall { get; set; }

        private string imageLocation;

        public string ImageLocation
        {
            get { return imageLocation; }
            set { imageLocation = value; }
        }

        public RightFall(String city, String addressFall, Coordinate coordinateF, DateTime date, String imageLocation)
        {
            CityFall = city;
            FallId = x;
            x++;
            AddressFall = addressFall;
            CoordinateF = coordinateF;
            DateFall = date;
            ImageLocation = imageLocation;
        }

        public RightFall()
        {
            FallId = x;
            x++;
            AddressFall = "Krinitsi 105";

            //LongFall = -1;
            //LatFall = -1;
            CoordinateF = new Coordinate(32.088139, 34.820330);
            DateFall = new DateTime();
            ImageLocation = "Ramat Gan";
        }

    }
}
