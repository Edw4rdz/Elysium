
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElysiumBusinessServices
{
        public class Validation
        {
            GetServices getservices = new GetServices();

            public bool CheckIfUserNameExists(string username)
            {
                bool result = getservices.GetUser(username) != null;
                return result;
            }

            public bool CheckIfUserExists(string username, string password, string email, string balance)
            {
                bool result = getservices.GetUser(username, password, email, balance) != null;
                return result;
            }
        }
    }