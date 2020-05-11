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
namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            this.Date.DisplayDateEnd = DateTime.Now;
           
            this.TimeTextBox.Text = DateTime.Now.ToShortTimeString();

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
        private void ReportViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMWPF.ViewModel.ReportViewModel reportViewModelObject =
               new MVVMWPF.ViewModel.ReportViewModel();
            reportViewModelObject.LoadStudents();

            ReportViewControl.DataContext = reportViewModelObject;
        }


        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            new FallingWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_2(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

     
        private void Button_Click(object sender, RoutedEventArgs e)

        {

            if (this.TimeTextBox.Text == "")
                MessageBox.Show("No text in Time");
            else
                      if (this.Date.Text == "")
                MessageBox.Show("No text in Date");
           
                 
            else
            {
                var h = int.Parse(this.TimeTextBox.Text[0].ToString()) * 10 + int.Parse(this.TimeTextBox.Text[1].ToString());
                var m = int.Parse(this.TimeTextBox.Text[3].ToString()) * 10 + int.Parse(this.TimeTextBox.Text[4].ToString());
                Random rnd = new Random();
                int x = rnd.Next(0, 59);
                DateTime dt = new DateTime(FactoryBl.GetBL().ChangeDateToNumber(this.Date.ToString()).Year, FactoryBl.GetBL().ChangeDateToNumber(this.Date.ToString()).Month, FactoryBl.GetBL().ChangeDateToNumber(this.Date.ToString()).Day, h, m, x);
                if (dt.Day == DateTime.Now.Day && dt.Month == DateTime.Now.Month && dt.Year == DateTime.Now.Year && dt.Hour == DateTime.Now.Hour && dt.Minute - 5 > DateTime.Now.Minute || dt.Day == DateTime.Now.Day && dt.Month == DateTime.Now.Month && dt.Year == DateTime.Now.Year && dt.Hour > DateTime.Now.Hour && dt.Minute - 5 > 0)
                    MessageBox.Show("Date not vailed");
                else
                if (this.IntensityTextBox.Text == "" || int.Parse(this.IntensityTextBox.Text) < 1)
                    MessageBox.Show("worng intensity");
                else
                    if (this.BoomsNTextBox.Text == "" || int.Parse(this.BoomsNTextBox.Text) < 1)
                    MessageBox.Show("worng Booms");
                else
                    if (this.CityTextBox.Text == "")
                    MessageBox.Show("No text in city");
                else
                    if (this.AddressTextBox.Text == "")
                    MessageBox.Show("No text in street");
                else
                    if (this.NameTextBox.Text == "")
                    MessageBox.Show("No text in Name");
                else
                {
                    var id = 0;
                    Geocoder g = new Geocoder();
                    var v = g.Geocode(AddressTextBox.Text, CityTextBox.Text);
                    if (v.Latitude == 0 && v.Longitude == 0)
                        MessageBox.Show("Sorry, but the address you gave does not exsist");
                    else
                    {
                        FactoryBl.GetBL().AddReport(new BE.Report(0, dt, this.NameTextBox.Text, this.AddressTextBox.Text, this.CityTextBox.Text, int.Parse(this.BoomsNTextBox.Text), int.Parse(this.IntensityTextBox.Text), new BE.Coordinate()));
                        foreach (var r in FactoryBl.GetBL().GetAllReport())
                            if (r.City == this.CityTextBox.Text && r.NameReporter == this.NameTextBox.Text && r.Address == this.AddressTextBox.Text)
                                id = r.FallId;
                        MapG w = new MapG(id);
                        w.Show();
                        this.Close();
                    }
                }
            }
        }
    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Date.Text = null;
            this.TimeTextBox.Text = DateTime.Now.ToShortTimeString();
            this.NameTextBox.Text = null;
            this.IntensityTextBox.Text = null;
            this.BoomsNTextBox.Text = null;
            this.CityTextBox.Text = null;
            this.AddressTextBox.Text = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
                new passWindow().Show();
                this.Close();
          
        }

        private void ListViewItem_Selected_3(object sender, RoutedEventArgs e)
        {
            new MapWindow().Show();
            this.Close();
        }

        private void ListViewItem_Selected_4(object sender, RoutedEventArgs e)
        {
            new InformationWindow().Show();
            this.Close();
        }
    }
}
