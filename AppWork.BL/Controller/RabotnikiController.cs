using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class RabotnikiController : MyControllerBase
    {
        public List<Rabotnikis> ListRabotniki { get; }
        public Rabotnikis CurrentRabotniki { get; set; }
        public bool IsNew { get; } = false;
        public RabotnikiController()
        {
            ListRabotniki = GetAllListRabotniki();
        }
        public RabotnikiController(string surname, string name, string patronymic, string login)
        {
            if (surname is null)
            {
                throw new ArgumentNullException(nameof(surname));
            }

            if (name is null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (patronymic is null)
            {
                throw new ArgumentNullException(nameof(patronymic));
            }

            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }


            //Delete();
            ListRabotniki = GetAllListRabotniki();

            CurrentRabotniki = ListRabotniki.SingleOrDefault(a => a.Surname == surname && a.Name == name && a.Patronymic == patronymic && a.Login == login);
            if (CurrentRabotniki == null)
            {
                CurrentRabotniki = new Rabotnikis(surname,name,patronymic,login);
                ListRabotniki.Add(CurrentRabotniki);
                IsNew = true;
            }
        }

        private List<Rabotnikis> GetAllListRabotniki()
        {
            return Load<Rabotnikis>() ?? new List<Rabotnikis>();
        }
        private void Delete()
        {
            Delete(ListRabotniki);

        }

        private void SaveList()
        {
            SaveList(ListRabotniki);

        }

        private void Save()
        {
            Save(CurrentRabotniki);

        }

        public void Set(string online)
        {
            if (online is null)
            {
                throw new ArgumentNullException(nameof(online));
            }
            CurrentRabotniki.Online = online;
            

            Save();
        }

    }
}
