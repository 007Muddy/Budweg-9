using ProjektBudweg.Model;
using ProjektBudweg.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class WhistleBlowerViewModel
    {

        private WhistleBlowerRepo _whistleblowerRepo = new WhistleBlowerRepo();

        public ObservableCollection<Message> WhistleBlowerList { get; set; } = new();



        public WhistleBlowerViewModel()
        {
            foreach (Message value in _whistleblowerRepo.GetAll())
            {
                WhistleBlowerList.Add(value);
            }
        }

    }
}
   