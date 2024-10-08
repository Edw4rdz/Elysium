using Elysium;
using ElysiumData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElysiumBusinessServices
{
    public class GetServices
    {
        public List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();
        }
        public User GetUser(string username)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username)
                {
                    foundUser = user;
                }
            }
            return foundUser;
        }
        public User GetUser(string username, string password, string email, string balance)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.username == username && user.password == password && user.email == email && user.balance == balance) 
                {
                    foundUser = user;
                }
            }
            return foundUser;


        }
    }
}