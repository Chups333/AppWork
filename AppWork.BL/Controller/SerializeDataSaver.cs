﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class SerializeDataSaver : IDataSaver 
    {
        public void Delete<T>(List<T> item) where T : class
        {
            throw new NotImplementedException();
        }

        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();

            var name = typeof(T).Name;

            using (var fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<T> items)
                {
                    return items;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var formatter = new BinaryFormatter();
            var name = typeof(T).Name;
            if (File.Exists(name))
            {
                File.Delete(name);
            }
            
            using (var fs = new FileStream(name, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
    }
}
