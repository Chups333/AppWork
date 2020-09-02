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
        private readonly User user;
        public List<LogZayavok> ListLogZayavok { get; }
        public ZayvkiController()
        {

        }
        public ZayvkiController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            //Delete();
            ListLogZayavok = GetAllListLogZayavok();

        }

        private List<LogZayavok> GetAllListLogZayavok()
        {
            return Load<LogZayavok>() ?? new List<LogZayavok>();
        }


        private void Delete()
        {
            Delete(ListLogZayavok);

        }

        private void Save()
        {
            Save(ListLogZayavok);

        }

        public void Add(string nomerNameZyavki, string status, User user)
        {
            var act = ListLogZayavok.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZyavki && a.Status == status && a.User == user);
            if (act == null)
            {
                act = new LogZayavok(nomerNameZyavki, status, user);
                ListLogZayavok.Add(act);
                
               
            }
            Delete();
            Save();


        }
    }
}
