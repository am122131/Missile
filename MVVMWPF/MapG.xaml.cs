using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BL;
using Microsoft.Maps.MapControl.WPF;

namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for MapG.xaml
    /// </summary>
    public partial class MapG : Window
    {
        public MapG(int id)
        {
            InitializeComponent();
            System.Media.SoundPlayer suodnsPlayer = new System.Media.SoundPlayer("C://Users//Havlin//Desktop//Music//mapg.wav");

            suodnsPlayer.Play();
            List <BE.Coordinate>myList = FactoryBl.GetBL().KMeansG(id).ToList();
           

            var locationList = new List<Location>();
            foreach (var v in myList)
                locationList.Add(new Location(v.Latitude, v.Longitude));

           
            var i = 1;

            foreach (var location in locationList)
            {
                var pushpin = new Pushpin();
                MapLayer.SetPosition(pushpin, location);
              
                MyMap.Children.Add(pushpin);
                i++;
            }
        

            }

        private void ButtonFlecher_Click(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
            this.Close();
        }
    }
}
