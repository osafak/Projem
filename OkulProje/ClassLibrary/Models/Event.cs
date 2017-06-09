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
        public string Ac { get; set; }
    }
}
