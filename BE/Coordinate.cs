using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class Coordinate
    {

        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public Coordinate()
        {
            Latitude = 0;
            Longitude = 0;
        }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

    }
}
