using Elysium;
namespace ElysiumData
{
        public class UserData
        {
            List<User> users;
            SqlDBData sqlData;
            public UserData()
            {
                users = new List<User>();
                sqlData = new SqlDBData();


            }
            public List<User> GetUsers()
            {
                users = sqlData.GetUsers();
                return users;
            }

            public int DeleteUser(User user)
            {
                return sqlData.DeleteUser(user.username);
            }
            public int AddUser(User user)
            {
                return sqlData.AddUser(user.username, user.password, user.email, user.balance);
            }
            public int UpdateUser(User user)
            {
                return sqlData.UpdateUser(user.username, user.password, user.email, user.balance);
            }
        }
    }

