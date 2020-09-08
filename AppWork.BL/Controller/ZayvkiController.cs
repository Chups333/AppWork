using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class ZayvkiController : MyControllerBase
    {
        public List<LogZayavoks> ListLogZayavok { get; }
        public LogZayavoks CurrentLogZayavok { get; set; }
        public bool IsNew { get; } = false;
        public ZayvkiController()
        {

        }
        public ZayvkiController(string nomerNameZyavki)
        {
            if (nomerNameZyavki is null)
            {
                throw new ArgumentNullException(nameof(nomerNameZyavki));
            }

            

            //Delete();
            ListLogZayavok = GetAllListLogZayavok();

            CurrentLogZayavok = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki);
            if (CurrentLogZayavok == null)
            {
                CurrentLogZayavok = new LogZayavoks(nomerNameZyavki);
                ListLogZayavok.Add(CurrentLogZayavok);
                IsNew = true;
            }

        }

        private List<LogZayavoks> GetAllListLogZayavok()
        {
            return Load<LogZayavoks>() ?? new List<LogZayavoks>();
        }


        private void Delete()
        {
            Delete(ListLogZayavok);

        }

        private void SaveList()
        {
            SaveList(ListLogZayavok);

        }

        private void Save()
        {
            Save(CurrentLogZayavok);

        }

        public void Set(string status, string iniciator, string ispolnitel, string shotOpisanie, string fullOpisanie)
        {
            if (status is null)
            {
                throw new ArgumentNullException(nameof(status));
            }

            if (iniciator is null)
            {
                throw new ArgumentNullException(nameof(iniciator));
            }

            if (ispolnitel is null)
            {
                throw new ArgumentNullException(nameof(ispolnitel));
            }

            if (shotOpisanie is null)
            {
                throw new ArgumentNullException(nameof(shotOpisanie));
            }

            if (fullOpisanie is null)
            {
                throw new ArgumentNullException(nameof(fullOpisanie));
            }
            CurrentLogZayavok.Status = status;
            CurrentLogZayavok.Iniciator = iniciator;
            CurrentLogZayavok.Ispolnitel = ispolnitel;
            CurrentLogZayavok.ShotOpisanie = shotOpisanie;
            CurrentLogZayavok.FullOpisanie = fullOpisanie;
            CurrentLogZayavok.Obrabotka = 0;

            //Delete();
            //SaveList();
            Save();


        }
    }
}
