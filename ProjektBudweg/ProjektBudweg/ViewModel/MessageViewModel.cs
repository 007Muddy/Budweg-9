using ProjektBudweg.Model;
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
        private DangerRepo dangerRepo = new DangerRepo();
        private FeedbackRepo feedbackRepo = new FeedbackRepo();
        private WhistleBlowerRepo whitleblowerRepo = new WhistleBlowerRepo();

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

    }
}
