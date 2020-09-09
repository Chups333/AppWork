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
        
        public RabotnikiController()
        {
            //DeleteList();
            ListRabotniki = GetAllListRabotniki();
        }

        private List<Rabotnikis> GetAllListRabotniki()
        {
            return Load<Rabotnikis>() ?? new List<Rabotnikis>();
        }
        private void DeleteList()
        {
            DeleteList(ListRabotniki);

        }

        private void Delete()
        {
            Delete(CurrentRabotniki);

        }

        private void Save()
        {
            Save(CurrentRabotniki);

        }
        private void Update()
        {
            Update(CurrentRabotniki);

        }

        public void Add(string surname, string name, string patronymic, string login, string online)
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

            if (online is null)
            {
                throw new ArgumentNullException(nameof(online));
            }

            CurrentRabotniki = ListRabotniki.SingleOrDefault(a => a.Surname == surname && a.Name == name && a.Patronymic == patronymic && a.Login == login);
            if (CurrentRabotniki == null)
            {
                CurrentRabotniki = new Rabotnikis(surname, name, patronymic, login, online);
                CurrentRabotniki.Count = 0;
                Save();

            }


            
        }

        public void UpdateItem(string surname, string name, string patronymic, string login, string online)
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

            if (online is null)
            {
                throw new ArgumentNullException(nameof(online));
            }

            CurrentRabotniki = ListRabotniki.SingleOrDefault(a => a.Login == login);
            if (CurrentRabotniki != null)
            {
                CurrentRabotniki.Surname = surname;
                CurrentRabotniki.Name = name;
                CurrentRabotniki.Patronymic = patronymic;
                CurrentRabotniki.Login = login;
                CurrentRabotniki.Online = online;


                Update();

            }
        }

        public void UpdateCount(string login, int count)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            CurrentRabotniki = ListRabotniki.SingleOrDefault(a => a.Login == login);
            if (CurrentRabotniki != null)
            {
                CurrentRabotniki.Count = count;


                Update();

            }
        }

        public void DeleteItem(string login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }


            CurrentRabotniki = ListRabotniki.SingleOrDefault(a => a.Login == login);
            if (CurrentRabotniki != null)
            { 

                Delete();

            }
        }

    }
}
