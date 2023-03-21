using ProjektBudweg.Model;
using ProjektBudweg.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ProjektBudweg.ViewModel
{
    public class DangerViewModel
    {
        private DangerRepo _dangerRepo = new DangerRepo();

        public ObservableCollection<Message> DangerList { get; set; } = new();
        


        public DangerViewModel()
        {
            foreach(Message value in _dangerRepo.GetAll())
            {
                DangerList.Add(value);
            }
        }

    }
}
