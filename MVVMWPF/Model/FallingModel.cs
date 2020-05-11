using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMWPF.Model
{
    class FallingModel
    {
        /* public Coordinate CoordinateF { get ; set; }
         public DateTime DateFalling { get; set; }
         public String City { get; set; }
         public String Street { get; set; }*/
        private Coordinate _CoordinateF;
        private DateTime _DateFalling;
        private String _City;
        private String _Street;
        public Coordinate CoordinateF
        {
            get { return _CoordinateF; }
            set
            {
                _CoordinateF = value;
                OnPropertyChanged("CoordinateF");
            }
        }
          public DateTime DateFalling
        {
            get { return _DateFalling; }
            set
            {
                _DateFalling = value;
                OnPropertyChanged("DateFalling");
            }
        }
        public String City
        {
            get { return _City; }
            set
            {
                _City = value;
                OnPropertyChanged("City");
            }
        }
        public String Street
        {
            get { return _Street; }
            set
            {
                _Street = value;
                OnPropertyChanged("Street");
            }
        }
            

       


        public event PropertyChangedEventHandler PropertyChanged;
        //This routine is called each time a property value has been set. This will
        //cause an event to notify WPF via data-binding that a change has occurred.
        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
