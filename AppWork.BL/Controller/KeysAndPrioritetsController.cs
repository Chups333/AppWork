using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class KeysAndPrioritetsController : MyControllerBase
    {
        public List<KeysAndPrioritets> ListKeysAndPrioritets { get; }
        public KeysAndPrioritets CurrentKeysAndPrioritets { get; set; }

        public KeysAndPrioritetsController()
        {
            //DeleteList();
            ListKeysAndPrioritets = GetAllListKeysAndPrioritets();
        }

        private List<KeysAndPrioritets> GetAllListKeysAndPrioritets()
        {
            return Load<KeysAndPrioritets>() ?? new List<KeysAndPrioritets>();
        }
        private void DeleteList()
        {
            DeleteList(ListKeysAndPrioritets);

        }

        private void Delete()
        {
            Delete(CurrentKeysAndPrioritets);

        }

        private void Save()
        {
            Save(CurrentKeysAndPrioritets);

        }
        private void Update()
        {
            Update(CurrentKeysAndPrioritets);

        }


        public void Add(string login, string nameKey, int prioritet)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (nameKey is null)
            {
                throw new ArgumentNullException(nameof(nameKey));
            }

            CurrentKeysAndPrioritets = ListKeysAndPrioritets.SingleOrDefault(a => a.Login == login && a.NameKey == nameKey);
            if (CurrentKeysAndPrioritets == null)
            {
                CurrentKeysAndPrioritets = new KeysAndPrioritets(login, nameKey, prioritet);
                
                Save();
            }
        }

        public void UpdateItem(string login, string nameKey, int prioritet)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (nameKey is null)
            {
                throw new ArgumentNullException(nameof(nameKey));
            }

            CurrentKeysAndPrioritets = ListKeysAndPrioritets.SingleOrDefault(a => a.Login == login && a.NameKey==nameKey);
            if (CurrentKeysAndPrioritets != null)
            {
                CurrentKeysAndPrioritets.Prioritet = prioritet;
                Update();

            }
        }


        public void DeleteItem(string login, string nameKey)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }


            CurrentKeysAndPrioritets = ListKeysAndPrioritets.SingleOrDefault(a => a.Login == login && a.NameKey == nameKey);
            if (CurrentKeysAndPrioritets != null)
            {

                Delete();

            }
        }

    }
}
