using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class DataBaseDataSaver : IDataSaver
    {
        public void Delete<T>(List<T> item) where T : class
        {
            using (var db = new AppWorkContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [RobotLogs]");

                //db.Set<T>().RemoveRange(db.Set<T>());
            }
        }

        public List<T> Load<T>() where T : class
        {

            using (var db = new AppWorkContext())
            {

                return db.Set<T>().Where(l => true).ToList();

            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new AppWorkContext())
            {
                db.Database.ExecuteSqlCommand("TRUNCATE TABLE [RobotLogs]");
                db.Set<T>().AddRange(item);

                //db.Set<T>().Distinct();


                db.SaveChanges();
            }

        }
    }
}
