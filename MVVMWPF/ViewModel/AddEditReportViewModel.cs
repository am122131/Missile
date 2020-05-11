using MVVMWPF.Command;
using MVVMWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMWPF.ViewModel
{
    class AddEditReportViewModel :BindableBase
    {
        public AddEditReportViewModel()
        {
            CancelCommand = new MyCommand(OnCancel);
            SaveCommand = new MyCommand(OnSave, CanSave);
        }
        private bool _EditMode;

        public bool EditMode
        {
            get { return _EditMode; }
            set { SetProperty(ref _EditMode, value); }
        }
        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public MyCommand CancelCommand { get; private set; }
        public MyCommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private async void OnSave()
        {
            Done();
        }

        private bool CanSave()
        {
            return !_report.HasErrors;
        }
        public SimpleEditableReport _report { get; set; }
        public ReportModel _editingReport = null;
        public void SetCustomer(ReportModel cust)
        {
            _editingReport = cust;

            if (_report != null) _report.ErrorsChanged -= RaiseCanExecuteChanged;
            _report = new SimpleEditableReport();
            _report.ErrorsChanged += RaiseCanExecuteChanged;
            //CopyCustomer(cust, Customer);
        }
    }
}