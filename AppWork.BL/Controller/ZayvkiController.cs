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
        public ZayvkiController(string nomerNameZyavki, string status)
        {
            if (nomerNameZyavki is null)
            {
                throw new ArgumentNullException(nameof(nomerNameZyavki));
            }

            if (status is null)
            {
                throw new ArgumentNullException(nameof(status));
            }

            //Delete();
            ListLogZayavok = GetAllListLogZayavok();

            CurrentLogZayavok = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki && a.Status == status);
            if (CurrentLogZayavok == null)
            {
                CurrentLogZayavok = new LogZayavoks(nomerNameZyavki, status);
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

        private void Save()
        {
            Save(ListLogZayavok);

        }

        public void Set(string iniciator, string ispolnitel, string shotOpisanie, string fullOpisanie)
        {
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
            CurrentLogZayavok.Iniciator = iniciator;
            CurrentLogZayavok.Ispolnitel = ispolnitel;
            CurrentLogZayavok.ShotOpisanie = shotOpisanie;
            CurrentLogZayavok.FullOpisanie = fullOpisanie;

            //Delete();
            Save();


        }
    }
}
