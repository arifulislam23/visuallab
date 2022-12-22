using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusSchedule.Data
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        public string DrverName { get; set; }
        public string DrverPhone { get; set; }
        public string DrverAddress { get; set; }
        public string DrverNID { get; set; }
    }
}
