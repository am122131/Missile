using BL;
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
    /// Interaction logic for AddFalling.xaml
    /// </summary>
    public partial class AddFalling : Window
    {
        public AddFalling()
        {
            InitializeComponent();
            this.TimeTextBox.Text = DateTime.Now.ToShortTimeString();
            DateRepTextBox.DisplayDateEnd = DateTime.Now;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CityTextBox.Text == "")
                MessageBox.Show("Worng city");
            else
                if (AddressTextBox.Text == "")
                MessageBox.Show("Worng street");
            else
                if (TimeTextBox.Text == "")
                MessageBox.Show("Worng time");
            else
                if (DateRepTextBox.Text == "")
                MessageBox.Show("Worng date");
            else
            {
                var d = FactoryBl.GetBL().ChangeDateToNumber(DateRepTextBox.Text);
                
                var h = int.Parse(TimeTextBox.Text[0].ToString()) * 10 + int.Parse(TimeTextBox.Text[1].ToString());
                var m = int.Parse(TimeTextBox.Text[3].ToString()) * 10 + int.Parse(TimeTextBox.Text[4].ToString());
                if (new DateTime(d.Year, d.Month, d.Day, h, m, 0) > DateTime.Now)
                    MessageBox.Show("Date not vailed");
                else
                FactoryBl.GetBL().AddFalling(new BE.Falling(this.CityTextBox.Text, this.AddressTextBox.Text, new DateTime(d.Year, d.Month, d.Day, h, m, 0), new BE.Coordinate()));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CityTextBox.Text = "";
            AddressTextBox.Text = "";
            TimeTextBox.Text = "";
            DateRepTextBox.Text = "";
        }

        private void ButtonFlecher_Click(object sender, RoutedEventArgs e)
        {
            new InformationWindow().Show();
            this.Close();
        }
    }
}
