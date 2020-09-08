using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public interface IDataSaver
    {
        
        void Save<T>(T item) where T : class;
        void DeleteList<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
        void Update<T>(T item) where T : class;
        void Delete<T>(T item) where T : class;
    }
}
