﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class LogZayavok //Activity
    {
        public int Id { get; set; }
        public string NomerNameZayavki { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public LogZayavok() { }

        public LogZayavok(string nomerNameZyavki, string status, User user)
        {
            NomerNameZayavki = nomerNameZyavki ?? throw new ArgumentNullException(nameof(nomerNameZyavki));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public override string ToString()
        {
            return NomerNameZayavki;
        }
    }
}
