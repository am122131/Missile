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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVMWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Media.SoundPlayer suodnsPlayer = new System.Media.SoundPlayer("C://Users//Havlin//Desktop//Music//home.wav");
           
            suodnsPlayer.Play();
      
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
    }
}
   