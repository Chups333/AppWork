using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class MyHistorys
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string NomerNameZayavki { get; set; }
        public DateTime DataTimeHistory { get; set; }

        public MyHistorys()
        {

        }

        public MyHistorys(string login, string nomerNameZayavki, DateTime dataTimeHistory)
        {
            

            Login = login ?? throw new ArgumentNullException(nameof(login));
            NomerNameZayavki = nomerNameZayavki ?? throw new ArgumentNullException(nameof(nomerNameZayavki));
            DataTimeHistory = dataTimeHistory;
        }

        public override string ToString()
        {
            return Login+" "+NomerNameZayavki+" "+DataTimeHistory.ToString();
        }
    }
}
