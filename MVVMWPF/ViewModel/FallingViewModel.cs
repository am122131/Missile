using BL;
using MVVMWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMWPF.ViewModel
{
    class FallingViewModel
    {
        public ObservableCollection<FallingModel> FallingCollection
        {
            get;
            set;
        }



        public void LoadStudents(String city, string date)
        {

            ObservableCollection<FallingModel> reportL = new ObservableCollection<FallingModel>();
            if (city != null && date != "")
            {
                if (date[3] == 0 || date[3] == 1)
                {
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {
                        if (v.City == city)
                            if (v.DateFalling.Year == 2000 + int.Parse(date[6].ToString()) * 10 + int.Parse(date[7].ToString()))
                                if (v.DateFalling.Month == int.Parse(date[3].ToString()) * 10 + int.Parse(date[4].ToString()))
                                    if (v.DateFalling.Day == int.Parse(date[0].ToString()) * 10 + int.Parse(date[1].ToString()))

                                        reportL.Add(new FallingModel { Street = v.Street, City = v.City, CoordinateF = v.CoordinateF, DateFalling = v.DateFalling });
                    }
                }
                else
                {
                    DateTime my = FactoryBl.GetBL().ChangeDateToNumber(date);
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {
                       
                            if (v.DateFalling.Year == my.Year)
                                if (v.DateFalling.Month == my.Month)
                                    if (v.DateFalling.Day == my.Day)

                                        reportL.Add(new FallingModel { Street = v.Street, City = v.City, CoordinateF = v.CoordinateF, DateFalling = v.DateFalling });
                    }
                }


            }
            else
            {
                if (city != null)
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {
                        if (v.City == city)


                            reportL.Add(new FallingModel { Street = v.Street, City = v.City, CoordinateF = v.CoordinateF, DateFalling = v.DateFalling });
                    }
                else if (date[3] == 0 || date[3] == 1)
                {
                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {

                        if (v.DateFalling.Year == 2000 + int.Parse(date[6].ToString()) * 10 + int.Parse(date[7].ToString()))
                            if (v.DateFalling.Month == int.Parse(date[3].ToString()) * 10 + int.Parse(date[4].ToString()))
                                if (v.DateFalling.Day == int.Parse(date[0].ToString()) * 10 + int.Parse(date[1].ToString()))

                                    reportL.Add(new FallingModel { Street = v.Street, City = v.City, CoordinateF = v.CoordinateF, DateFalling = v.DateFalling });
                    }
                }


                else
                {
                    DateTime my = FactoryBl.GetBL().ChangeDateToNumber(date);

                    foreach (var v in FactoryBl.GetBL().GetAllFalling())
                    {
                        if (v.DateFalling.Year == my.Year)
                            if (v.DateFalling.Month == my.Month)
                                if (v.DateFalling.Day == my.Day)

                                    reportL.Add(new FallingModel { Street = v.Street, City = v.City, CoordinateF = v.CoordinateF, DateFalling = v.DateFalling });
                    }

                }
            }
            FallingCollection = reportL;// = reportL;
        }
           
        }

    }

