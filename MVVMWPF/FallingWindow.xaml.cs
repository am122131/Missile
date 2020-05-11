using Microsoft.Win32;
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
using BL;
using System.IO;
using Microsoft.Maps.MapControl.WPF;

namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for FallingWindow.xaml
    /// </summary>
    public partial class FallingWindow : Window
    {
        public FallingWindow()
        {
            InitializeComponent();
            this.datep.DisplayDateEnd = DateTime.Now;
            
        }

        private void ButtonFlecher_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #region
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.datep.Text == "")
                MessageBox.Show("you did not write a date");

            else
            {
                //   MessageBox.Show("Not vailed date");
                List<BE.Coordinate> myList = FactoryBl.GetBL().GetFallingsByDateOrCity(this.datep.Text);


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
        }
        #endregion

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
            var c = FactoryBl.GetBL().PhotoToC(imgPhoto.Source.ToString());
            MessageBox.Show("The hit added thanks for your help");


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new passWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            new FallingWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            new MapWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_5(object sender, RoutedEventArgs e)
        {

            new InformationWindow().Show();
            this.Close();
        }
    }
}