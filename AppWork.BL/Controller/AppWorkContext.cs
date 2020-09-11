using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class AppWorkContext : DbContext
    {
        public AppWorkContext() : base("SANCHDBDB")
        {

        }

        public DbSet<RobotLogs> RobotLogsSet { get; set; }
        public DbSet<LogZayavoks> LogZayavoksSet { get; set; }
        public DbSet<Rabotnikis> RabotnikisSet { get; set; }
        public DbSet<MyHistorys> HistorysSet { get; set; }
        public DbSet<KeysAndPrioritets> KeysAndPrioritetsSet { get; set; }



    }
}
