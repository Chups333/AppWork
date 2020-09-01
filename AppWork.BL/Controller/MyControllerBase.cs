using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public abstract class MyControllerBase
    {
        protected IDataSaver mymanager = new SerializeDataSaver();
        protected void Save<T>(List<T> item) where T : class
        {
            mymanager.Save(item);
        }
        protected List<T> Load<T>() where T : class
        {
            return mymanager.Load<T>();
        }
        protected void Delete<T>(List<T> item) where T : class
        {
            mymanager.Delete(item);
        }
    }
}
