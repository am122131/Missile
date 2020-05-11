using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public class Falling
    {
        public static int x = 30;
        [Key]
        [Column(Order = 1)]
        public int FallId { get; set; }

        public Coordinate CoordinateF { get; set; }
        public DateTime DateFalling { get; set; }
        public String City { get; set; }
        public String Street { get; set; }

        public Falling()
        {
            FallId = x;
            x++;
            DateFalling = DateTime.Now;
            City = "Ramat Gan";
            Street = "Krinitsi 105";
            CoordinateF = new Coordinate(32.088139, 34.820330);

        }
        public Falling(String city, String street, DateTime d, Coordinate c)
        {
            FallId = x;
            x++;
            City = city;
            Street = street;
            DateFalling = d;
            CoordinateF = c;
        }
    }
}
