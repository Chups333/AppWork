using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public abstract class MyControllerBase
    {
        protected IDataSaver mymanager = new DataBaseDataSaver();
        protected void Save<T>(T item) where T : class
        {
            mymanager.Save(item);
        }
        protected void Update<T>(T item) where T : class
        {
            mymanager.Update(item);
        }
        protected void Delete<T>(T item) where T : class
        {
            mymanager.Delete(item);
        }
        protected List<T> Load<T>() where T : class
        {
            return mymanager.Load<T>();
        }
        protected void DeleteList<T>(List<T> item) where T : class
        {
            mymanager.DeleteList(item);
        }
    }
}
