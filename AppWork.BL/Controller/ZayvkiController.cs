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
        public List<CountZayavok> ListCountZayavok{ get; }
        public List<LogZayavok> ListLogZayavok { get; }

        public ZayvkiController()
        {
            //Delete();
            ListLogZayavok = GetAllListLogZayavok();
            ListCountZayavok = GetAllListCountZayavok();
        }

        private List<LogZayavok> GetAllListLogZayavok()
        {
            return Load<LogZayavok>() ?? new List<LogZayavok>();
        }

        private List<CountZayavok> GetAllListCountZayavok()
        {
            return Load<CountZayavok>() ?? new List<CountZayavok>();
        }

        private void Delete()
        {
            Delete(ListLogZayavok);
            Delete(ListCountZayavok);
        }

        private void Save()
        {   
            Save(ListLogZayavok); 
            Save(ListCountZayavok);
        }

        public void Add(int count, LogZayavok logZayavok)
        {
            var act = ListLogZayavok.FirstOrDefault(a => a.NomerNameZayavki == logZayavok.NomerNameZayavki && a.Status==logZayavok.Status);
            if (act == null)
            {
                ListLogZayavok.Add(logZayavok);
                var countZayavok = new CountZayavok(count, logZayavok);
                ListCountZayavok.Add(countZayavok);
                //Delete();
                Save();
            }
            else
            {
                return;

            }
            
        }
    }
}
