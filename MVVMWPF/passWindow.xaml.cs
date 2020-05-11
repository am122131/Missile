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
    /// Interaction logic for passWindow.xaml
    /// </summary>
    public partial class passWindow : Window
    {
        public passWindow()
        {
            InitializeComponent();
        }

        private void ButtonFlecher_Click(object sender, RoutedEventArgs e)
        {
            new InformationWindow().Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(pass.Text=="1234")
            {
                new AddFalling().Show();
                this.Close();
            
            }
            else
            {
                MessageBox.Show("worng password");
                new InformationWindow().Show();
                this.Close();

            }
        }
    }
}
