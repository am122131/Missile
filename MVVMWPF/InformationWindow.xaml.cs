using BL;
using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Threading;

namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for InformationWindow.xaml
    /// </summary>
    public partial class InformationWindow : Window
    {
      
        public InformationWindow()
        {
            InitializeComponent();
        
            this.Number.Text = "100";
            DayC.Text = String.Format("{0:0.00}",FactoryBl.GetBL().todayC(int.Parse(Number.Text))*100)+"%";
            Month.Text = DateTime.Now.Month.ToString();
            
            List<double> m = new List<double>();
            m.Add(3);
            m.Add(5);
            m.Add(7);
            CartesianChart ch = new CartesianChart();
            CartesianChart ch2 = new CartesianChart();
            var v = (FactoryBl.GetBL().YearByMonthC(int.Parse(Number.Text)).ToArray());
            
                
            ch.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Series 1",
          //  Values=new ChartValues<double>(m.ToArray())
         Values = new ChartValues<double>(FactoryBl.GetBL().MonthBydayC(int.Parse(Number.Text),int.Parse(Month.Text)).ToArray()) 
        }
    };

            GridTest.Children.Add(ch);


            ch2.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Series 2",
         
             Values =new ChartValues<double>(v)
        }
    };

            GridTest2.Children.Add(ch2);
            System.Media.SoundPlayer suodnsPlayer = new System.Media.SoundPlayer("C://Users//Havlin//Desktop//Music//information.wav");

            suodnsPlayer.Play();
        }
        public InformationWindow(int num,int x)
        {
            InitializeComponent();

            this.Number.Text = num+"";
            DayC.Text = String.Format("{0:0.00}",FactoryBl.GetBL().todayC(int.Parse(Number.Text)) * 100) + "%";
            Month.Text = x+"";

          
            CartesianChart ch = new CartesianChart();
            CartesianChart ch2 = new CartesianChart();
            ch.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Series 1",
          //  Values=new ChartValues<double>(m.ToArray())
         Values = new ChartValues<double>(FactoryBl.GetBL().MonthBydayC(int.Parse(Number.Text),int.Parse(Month.Text)).ToArray())
        }
    };

            GridTest.Children.Add(ch);


            ch2.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Series 2",
            Values = new ChartValues<double> (FactoryBl.GetBL().YearByMonthC(int.Parse(Number.Text)).ToArray())
        }
    };

            GridTest2.Children.Add(ch2);

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (int.Parse(Month.Text) > DateTime.Now.Month)
                MessageBox.Show("Not vaile month");
            else
            {
                new InformationWindow(int.Parse(Number.Text), int.Parse(Month.Text)).Show();
                this.Close();
            }
        }
    }
}
