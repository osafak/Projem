using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string ActivityName { get; set; }
        public EventType ActivityType { get; set; }
        public DateTime ActivityDate { get; set; }
        public Saloon SaloonID { get; set; }
        public int GuessLimit { get; set; }
        public Speaker SpeakersID { get; set; }
        public Worker WorkersID { get; set; }
        public string ActivityPhoto { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
