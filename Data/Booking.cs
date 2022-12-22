using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusSchedule.Data
{
    public class Booking
    {
        [Key]
        public int Bid { get; set; }
        public string Location { get; set; }
        public string BusNumber { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime JDate{ get; set; }
    }
}
