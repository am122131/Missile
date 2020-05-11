using BL;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        public MapWindow()
        {
            InitializeComponent();
           DT.DisplayDateEnd = DateTime.Now;
            List<BE.Coordinate> myList1 = FactoryBl.GetBL().TodayKMeansG().ToList();
            List<BE.Coordinate> myList2 = FactoryBl.GetBL().TodayFalling().ToList();


            var locationList = new List<Location>();
            foreach (var v in myList1)
                locationList.Add(new Location(v.Latitude, v.Longitude));
            var locationList2 = new List<Location>();
            foreach (var v in myList2)
                locationList2.Add(new Location(v.Latitude, v.Longitude));


            var i = 1;

            foreach (var location in locationList)
            {
                var pushpin = new Pushpin();
                pushpin.Background = new SolidColorBrush(Color.FromArgb(20,20,20,20));
                MapLayer.SetPosition(pushpin, location);
                MyMap.Children.Add(pushpin);
                i++;
            }
            foreach (var location in locationList2)
            {
                var pushpin = new Pushpin();
              
                MapLayer.SetPosition(pushpin, location);
                MyMap.Children.Add(pushpin);
                i++;
            }
        }
        public MapWindow(String date)
        {
            InitializeComponent();
            DT.DisplayDateEnd = DateTime.Now;
            var dt = FactoryBl.GetBL().ChangeDateToNumber(date);
            List<BE.Coordinate> myList1 = FactoryBl.GetBL().KMeansGByDate(dt).ToList();
            List<BE.Coordinate> myList2 = FactoryBl.GetBL().FallingByDate(dt).ToList();


            var locationList = new List<Location>();
            foreach (var v in myList1)
                locationList.Add(new Location(v.Latitude, v.Longitude));
            var locationList2 = new List<Location>();
            foreach (var v in myList2)
                locationList2.Add(new Location(v.Latitude, v.Longitude));


            var i = 1;

            foreach (var location in locationList)
            {
                var pushpin = new Pushpin();
                pushpin.Background = new SolidColorBrush(Color.FromArgb(20, 20, 20, 20));
                MapLayer.SetPosition(pushpin, location);
                MyMap.Children.Add(pushpin);
                i++;
            }
            foreach (var location in locationList2)
            {
                var pushpin = new Pushpin();

                MapLayer.SetPosition(pushpin, location);
                MyMap.Children.Add(pushpin);
                i++;
            }
        }

        private void ButtonFlecher_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void ListViewMenu_SelectionChanged(object sender, System.EventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            ReportWindow w = new ReportWindow();
            w.Show();
            this.Close();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            FallingWindow w = new FallingWindow();
            w.Show();
            this.Close();

        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            new MapWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            new InformationWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            new MapWindow().Show();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new passWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            new MapWindow(DT.Text).Show();
            this.Close();
        }
    }
}

