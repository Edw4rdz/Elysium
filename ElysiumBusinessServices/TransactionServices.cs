using ElysiumData;
using Elysium;

namespace ElysiumBusinessServices
{
    public class TransactionServices()

    {
        Validation validationServices = new Validation();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string username, string password, string email, string balance)
        {
            User user = new User { username = username, password = password, email = email, balance = balance };

            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string username, string password, string email, string balance)
        {
            User user = new User { username = username, password = password, email = email, balance = balance };

            return UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.username))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }
    }
}
