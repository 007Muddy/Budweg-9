using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
   public class Message
    {
        public int MessageID { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsAnonym { get; set; }
      


        public Message(int MessageID,string type, DateTime date, string description, bool isAnonym)
        {
            this.MessageID = MessageID;
            Type = type;
            Date = date;
            Description = description;
            IsAnonym = isAnonym;
         
        }



    }
} 
