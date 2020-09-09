using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class HistorysController : MyControllerBase
    {
        public List<MyHistorys> ListHistorys { get; }
        public MyHistorys CurrentHistory { get; set; }

        public HistorysController()
        {
            //DeleteList();
            ListHistorys = GetAllListRabotniki();
        }

        private List<MyHistorys> GetAllListRabotniki()
        {
            return Load<MyHistorys>() ?? new List<MyHistorys>();
        }
        private void DeleteList()
        {
            DeleteList(ListHistorys);

        }

        private void Delete()
        {
            Delete(CurrentHistory);

        }

        private void Save()
        {
            Save(CurrentHistory);

        }
        private void Update()
        {
            Update(CurrentHistory);

        }

        //public void Add(string login, string nomerNameZayavki, DateTime dateTimeHistory)
        //{
        //    if (login is null)
        //    {
        //        throw new ArgumentNullException(nameof(login));
        //    }

        //    if (nomerNameZayavki is null)
        //    {
        //        throw new ArgumentNullException(nameof(nomerNameZayavki));
        //    }

        //    CurrentHistory = ListHistorys.SingleOrDefault(a => a.Login == login && a.NomerNameZayavki == nomerNameZayavki && a.DataTimeHistory == dateTimeHistory);
        //    if (CurrentHistory == null)
        //    {
        //        CurrentHistory = new MyHistorys(login, nomerNameZayavki, dateTimeHistory);
        //        Save();
        //    }
        //}

        public void AddUpdateLoginDataTime(string login, string nomerNameZayavki, DateTime dateTimeHistory)
        {

            CurrentHistory = ListHistorys.SingleOrDefault(a => a.NomerNameZayavki == nomerNameZayavki);
            if (CurrentHistory != null)
            {
                CurrentHistory.Login = login;
                CurrentHistory.DataTimeHistory = dateTimeHistory;
                Update();
            }
            else
            {
                CurrentHistory = new MyHistorys(login, nomerNameZayavki, dateTimeHistory);
                Save();
            }
        }

        public void DeleteHistory(string login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }


            CurrentHistory = ListHistorys.SingleOrDefault(a => a.Login == login);
            if (CurrentHistory != null)
            {
                Delete();
            }
        }

    }
}
