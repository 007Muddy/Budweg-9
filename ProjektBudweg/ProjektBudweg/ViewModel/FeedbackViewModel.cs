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
    public class FeedbackViewModel
    {
        private FeedbackRepo _dangerRepo = new FeedbackRepo();

        public ObservableCollection<Message> FeedbackList { get; set; } = new();



        public FeedbackViewModel()
        {
            foreach (Message value in _dangerRepo.GetAll())
            {
                FeedbackList.Add(value);
            }
        }

    }
}