using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary.Models
{
    public class Worker
    {
        public int ID { get; set; }
        public User UserID { get; set; }
        public string WorkerMission { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
