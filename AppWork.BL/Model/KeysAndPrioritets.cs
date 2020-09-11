using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    public class KeysAndPrioritets
    {
        public int Id { get; set; }
        public string NameKey { get; set; }
        public int Prioritet { get; set; }
        public string Login { get; set; }

        public KeysAndPrioritets()
        {
                
        }
        public KeysAndPrioritets(string login, string nameKey, int prioritet)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            NameKey = nameKey ?? throw new ArgumentNullException(nameof(nameKey));
            Prioritet = prioritet;
        }

        public override string ToString()
        {
            return Login + " " + NameKey + " " + Prioritet.ToString();
        }
    }
}
