using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMWPF.Model
{
    class ReportModel : INotifyPropertyChanged
    {
        // Report r = null;

        /* public String NameReporter { get; set; }
         public String DateRep { get; set; }
         public String TimeRep { get; set; }
         public String Address { get; set; }

         public String City { get; set; }

         public int BoomsN { get; set; }

         public int Intensity { get; set; }*/
        private String _NameReporter;
        private String _DateRep;
        private String _TimeRep;
        private String _Address;

        private String _City;

        private int _BoomsN;

        private int _Intensity;
        public String NameReporter {
            get { return _NameReporter; }
            set {
                _NameReporter = value;
                OnPropertyChanged("NameReporter");

            }
        }
        public String DateRep
        {
            get { return _DateRep; }
            set
            {
                _DateRep = value;
                OnPropertyChanged("DateRep");

            }
        }
        public String TimeRep
        {
            get { return _TimeRep; }
            set
            {
                _TimeRep = value;
                OnPropertyChanged("TimeRep");

            }
        }
        public String Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                OnPropertyChanged("Address");

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

        public int BoomsN
        {
            get { return _BoomsN; }
            set
            {
                _BoomsN = value;
                OnPropertyChanged("BoomsN");

            }
        }

        public int Intensity
        {
            get { return _Intensity; }
            set
            {
                _Intensity = value;
                OnPropertyChanged("Intensity");

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