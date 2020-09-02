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
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        public UserController(string login)
        {
            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            Users = GetUsersData();

            if (CurrentUser == null)
            {
                CurrentUser = new User(login);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }

        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }

        public void Save()
        {
            Save(Users);
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
            Save();
        }

    }
}
