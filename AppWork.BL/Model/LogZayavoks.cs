using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class LogZayavoks //Activity
    {
        public int Id { get; set; }
        public string NomerNameZayavki { get; set; }
        public string Status { get; set; }

        public LogZayavoks() { }

        public LogZayavoks(string nomerNameZyavki, string status)
        {
            NomerNameZayavki = nomerNameZyavki ?? throw new ArgumentNullException(nameof(nomerNameZyavki));
            Status = status ?? throw new ArgumentNullException(nameof(status));

        }

        public override string ToString()
        {
            return NomerNameZayavki;
        }
    }
}
