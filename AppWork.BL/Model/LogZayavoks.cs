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
        public string ShotOpisanie { get; set; }
        public string FullOpisanie { get; set; }
        public string Iniciator { get; set; }
        public string Ispolnitel { get; set; }


        public LogZayavoks() { }

        public LogZayavoks(string nomerNameZyavki, string status, string iniciator, string ispolnitel, string shotOpisanie, string fullOpisanie)
        {
            NomerNameZayavki = nomerNameZyavki ?? throw new ArgumentNullException(nameof(nomerNameZyavki));
            Status = status ?? throw new ArgumentNullException(nameof(status));
            Iniciator = iniciator ?? throw new ArgumentNullException(nameof(iniciator));
            Ispolnitel = ispolnitel ?? throw new ArgumentNullException(nameof(ispolnitel));
            ShotOpisanie = shotOpisanie ?? throw new ArgumentNullException(nameof(shotOpisanie));
            FullOpisanie = fullOpisanie ?? throw new ArgumentNullException(nameof(fullOpisanie));
        }

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
