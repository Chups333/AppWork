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

        public ZayvkiController()
        {
            //DeleteList();
            ListLogZayavok = GetAllListLogZayavok();
        }

        private List<LogZayavoks> GetAllListLogZayavok()
        {
            return Load<LogZayavoks>() ?? new List<LogZayavoks>();
        }


        private void DeleteList()
        {
            DeleteList(ListLogZayavok);

        }


        private void Save()
        {
            Save(CurrentLogZayavok);

        }
        private void Update()
        {
            Update(CurrentLogZayavok);

        }

        public void Add(string nomerNameZyavki, string status, string iniciator, string ispolnitel, string shotOpisanie, string fullOpisanie)
        {
            if (nomerNameZyavki is null)
            {
                throw new ArgumentNullException(nameof(nomerNameZyavki));
            }

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

            CurrentLogZayavok = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki);
            if (CurrentLogZayavok == null)
            {
                CurrentLogZayavok = new LogZayavoks(nomerNameZyavki, status, iniciator, ispolnitel, shotOpisanie, fullOpisanie);
                CurrentLogZayavok.Obrabotka = 0;
                Save();
            }

        }

        public void UpdateIspolnitel(string nomerNameZyavki, string ispolnitel)
        {
            if (ispolnitel is null)
            {
                throw new ArgumentNullException(nameof(ispolnitel));
            }

            CurrentLogZayavok = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki);
            if (CurrentLogZayavok != null)
            {
                CurrentLogZayavok.Ispolnitel = ispolnitel;


                Update();

            }
        }

        public void UpdateObrabotka(string nomerNameZyavki)
        {
            CurrentLogZayavok = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki);
            if (CurrentLogZayavok != null)
            {
                CurrentLogZayavok.Obrabotka = 1;


                Update();

            }
        }
    }
}
