using AppWork.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWork.BL.Controller
{
    public class UserController : MyControllerBase
    {
        public List<Users> Users { get; }
        public Users CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }
            //Delete();
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(a => a.Login == login);

            if (CurrentUser == null)
            {
                CurrentUser = new Users(login);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        private List<Users> GetUsersData()
        {
            return Load<Users>() ?? new List<Users>();
        }

        public void SaveList()
        {
            SaveList(Users);
        }
        private void Save()
        {
            Save(CurrentUser);

        }
        public void Delete()
        {
            Delete(Users);
        }

        public void SetNewUserData(string pass)
        {
            if (pass is null)
            {
                throw new ArgumentNullException(nameof(pass));
            }

            CurrentUser.Pass = pass;
            //SaveList();
            Save();
        }

    }
}
