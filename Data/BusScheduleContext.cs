using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusSchedule.Data;

namespace BusSchedule.Data
{
    public class BusScheduleContext : DbContext
    {
        public BusScheduleContext (DbContextOptions<BusScheduleContext> options)
            : base(options)
        {
        }

        public DbSet<BusSchedule.Data.BusInfo> BusInfo { get; set; }
        public DbSet<BusSchedule.Data.Booking> Booking { get; set; }
        public DbSet<BusSchedule.Data.Driver> Driver { get; set; }
    }
}
