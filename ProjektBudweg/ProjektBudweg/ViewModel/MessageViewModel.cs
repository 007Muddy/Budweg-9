using ProjektBudweg.Model;
using ProjektBudweg.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class MessageViewModel : INotifyPropertyChanged
    {

        private Message message { get; set; }
        private MessageRepo _messageRepo = new MessageRepo();

        public ObservableCollection<Department.DepartmentArea> DepartmentList { get; private set; }

        private string departmentArea;

        public string DepartmentArea
        {
            get { return departmentArea; }
            set
            {
                if (value != departmentArea)
                {
                    departmentArea = value;
                    NotifyPropertyChanged(nameof(DepartmentArea));
                }
            }
        }


        public ObservableCollection<RiskLevel.Risk> RiskList { get; private set; }

        private string riskLevel;

        public string RiskLevel
        {
            get { return riskLevel; }
            set
            {
                if (value != riskLevel)
                {
                    riskLevel = value;
                    NotifyPropertyChanged(nameof(RiskLevel));
                }
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MessageViewModel()
        {
            RiskList = new ObservableCollection<RiskLevel.Risk>();
            DepartmentList = new ObservableCollection<Department.DepartmentArea>();
        }

        public void ShowEnumList()
        {
            try
            {
                var riskValues = Enum.GetValues(typeof(RiskLevel.Risk));
                foreach (var value in riskValues)
                {
                    RiskList.Add((RiskLevel.Risk)value);
                }

                var departmentValues = Enum.GetValues(typeof(Department.DepartmentArea));
                foreach (var value in departmentValues)
                {
                    DepartmentList.Add((Department.DepartmentArea)value);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool AddMessage(string name, string lastName, string msg)
        {
            bool messageTransmitted = false;
            DateTime date = DateTime.Now;
            try
            {
                if (name != null && lastName != null && RiskLevel != null && DepartmentArea != null && msg != null)
                {
                    _messageRepo.AddMessage(name, lastName, RiskLevel, DepartmentArea, date, msg);
                    messageTransmitted = true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return messageTransmitted;
        }

    }
}
