using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public Users()
        {

        }
        public Users(string login, string pass)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Pass = pass ?? throw new ArgumentNullException(nameof(pass));
        }
        public Users(string login)
        {
            Login = login ?? throw new ArgumentNullException(nameof(login));
        }
        public override string ToString()
        {
            return Login;
        }
    }
}
