using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using BL;
using MVVMWPF.Model;

namespace MVVMWPF.ViewModel
{
    class ReportViewModel
    {
        public ObservableCollection<ReportModel> reportCollection
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<ReportModel> reportL = new ObservableCollection<ReportModel>();
            foreach (var v in FactoryBl.GetBL().GetAllReport())
            {
                if(v.DateRep.Day==DateTime.Now.Day&& v.DateRep.Year == DateTime.Now.Year && v.DateRep.Month == DateTime.Now.Month)
                reportL.Add(new ReportModel { Address = v.Address, City = v.City, BoomsN = v.BoomsN, Intensity = v.Intensity });
            }

            reportCollection = reportL;
        }

                    
                

    }
}