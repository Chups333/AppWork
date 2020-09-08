using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Model
{
    [Serializable]
    public class Rabotnikis
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Login { get; set; }
        public string Online { get; set; }
        public Rabotnikis()
        {

        }
        public Rabotnikis(string surname, string name, string patronymic, string login, string online)
        {
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Patronymic = patronymic ?? throw new ArgumentNullException(nameof(patronymic));
            Login = login ?? throw new ArgumentNullException(nameof(login));
            Online = online ?? throw new ArgumentNullException(nameof(online));
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic + " " + Login;
        }



    }
}
