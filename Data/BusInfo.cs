using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusSchedule.Data
{
    public class BusInfo
    {
        [Key]
        public int Busid { get; set; }
        public string BusNumber { get; set; }
        public string busName { get; set; }
        public int BusSit { get; set; }
        public string BusDriver { get; set; }
    }
}
