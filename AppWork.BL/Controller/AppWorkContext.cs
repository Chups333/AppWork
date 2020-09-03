﻿using AppWork.BL.Model;
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
        public AppWorkContext() : base("APPWORKDB")
        {

        }
        public DbSet<Users> UsersSet { get; set; }
        public DbSet<RobotLogs> RobotLogsSet { get; set; }
        public DbSet<LogZayavoks> LogZayavoksSet { get; set; }

        

    }
}
