using BE;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
namespace BL
{
    class KMeans
    {
        Geocoder g = new Geocoder();

        public List<Report> ReportsList { get; set; }
        public int K { get; set; }

        public KMeans(ICollection<Report> reportsList, int k)
        {
            ReportsList = reportsList.ToList();
            K = k;
        }

        public List<GeoCoordinate> K_Means()
        {
            if (ReportsList.Count == 0)
                return null;

            List<GeoCoordinate> clustersIdList = ClustersGenerator();

            bool isClustersChanged;
            var counter = 0;
            do
            {
                isClustersChanged = false;
                //for each report looking for the closest cluster 
                for (int i = 0; i < ReportsList.Count; i++)
                {
                    double min = g.GetDistanceBetweenPoints(ReportsList[i].CoordinateR, new Coordinate(clustersIdList[0].Latitude, clustersIdList[0].Longitude));

                    //ReportsList[i].g().GetDistanceTo(clustersIdList[0]);
                    ReportsList[i].FallId = 0;

                    for (int j = 1; j < clustersIdList.Count; j++)
                    {
                        double temp = g.GetDistanceBetweenPoints(ReportsList[i].CoordinateR, new Coordinate(clustersIdList[j].Latitude, clustersIdList[j].Longitude));
                        if (temp < min)
                        {
                            min = temp;
                            isClustersChanged = true;
                            ReportsList[i].FallId = j;
                        }
                    }

                }
                counter++;
                clustersIdList = RecenterClusters(clustersIdList);
                if (counter == 100)
                {
                    break;
                }
            } while (isClustersChanged);

            return clustersIdList;
        }

        private List<GeoCoordinate> RecenterClusters(List<GeoCoordinate> clustersIdList)
        {
            //Recenter the clusters
            ReportsList = ReportsList.OrderBy(c => c.FallId).ToList();
            int id = 0;
            double clustersLongitudeSum = 0;
            double clustersLatitudeSum = 0;
            int counter = 0;
            for (int i = 0; i < ReportsList.Count; i++)
            {
                if (ReportsList[i].FallId == id)
                {
                    clustersLatitudeSum += ReportsList[i].CoordinateR.Latitude;
                    clustersLongitudeSum += ReportsList[i].CoordinateR.Longitude;
                    counter++;
                }
                else if (ReportsList[i].FallId != id)
                {
                    clustersIdList[id].Latitude = clustersLatitudeSum / counter;
                    clustersIdList[id].Longitude = clustersLongitudeSum / counter;
                    counter = 0;
                    clustersLongitudeSum = 0;
                    clustersLatitudeSum = 0;
                    i--;
                    id++;
                }
            }
            clustersIdList[id].Latitude = clustersLatitudeSum / counter;
            clustersIdList[id].Longitude = clustersLongitudeSum / counter;
            return clustersIdList;

        }

        private List<GeoCoordinate> ClustersGenerator()
        {

            List<GeoCoordinate> clustersIdList = new List<GeoCoordinate>();

            double minLatitude = ReportsList.Min(r => r.CoordinateR.Latitude);
            double maxLatitude = ReportsList.Max(r => r.CoordinateR.Latitude);
            double minLongitude = ReportsList.Min(r => r.CoordinateR.Longitude);
            double maxLongitude = ReportsList.Max(r => r.CoordinateR.Longitude);

            for (int i = 0; i < K; i++)
            {
                Random rand = new Random(i);
                double latitude = minLatitude + rand.NextDouble() * (maxLatitude - minLatitude);
                double longitude = minLongitude + rand.NextDouble() * (maxLongitude - minLongitude);
                GeoCoordinate coordinate = new GeoCoordinate(latitude, longitude);
                clustersIdList.Add(coordinate);
            }

            return clustersIdList;
        }


    }
}

