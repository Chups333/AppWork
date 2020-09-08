using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class DataBaseDataSaver : IDataSaver
    {
        public void DeleteList<T>(List<T> item) where T : class
        {
            using (var db = new AppWorkContext())
            {
                //db.Set<T>().RemoveRange(db.Set<T>());
                db.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{typeof(T).Name}]");
                db.SaveChanges();
            }
        }

        public List<T> Load<T>() where T : class
        {

            using (var db = new AppWorkContext())
            {

                return db.Set<T>().Where(l => true).ToList();


            }
        }

        public void Save<T>(T item) where T : class
        {
            using (var db = new AppWorkContext())
            {

                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }



        public void SaveList<T>(List<T> item) where T : class
        {
            using (var db = new AppWorkContext())
            {
                db.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{typeof(T).Name}]");
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }

        public void Update<T>(T item) where T : class
        {
            using (var db = new AppWorkContext())
            {

                db.Set<T>().AddOrUpdate(item);
                db.SaveChanges();
            }
        }

        public void Delete<T>(T item) where T : class
        {
            using (var db = new AppWorkContext())
            {
                var entry = db.Entry(item);
                if (entry.State == EntityState.Detached)
                    db.Set<T>().Attach(item);
                db.Set<T>().Remove(item);
                db.SaveChanges();
            }
        }
    }
}
