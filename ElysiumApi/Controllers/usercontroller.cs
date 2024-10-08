using ElysiumBusinessServices;
using Microsoft.AspNetCore.Mvc;

namespace ElysiumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usercontroller : ControllerBase
    {
        GetServices userGetServices;
        TransactionServices userTransactionServices;

        public usercontroller()
        {
            userGetServices = new GetServices();
            userTransactionServices = new TransactionServices();
        }

        [HttpGet]
        public IEnumerable<ElysiumApi.User> GetUsers()
        {
            var activeusers = userGetServices.GetAllUsers();

            List<ElysiumApi.User> users = new List<User>();

            foreach (var item in activeusers)
            {
                users.Add(new ElysiumApi.User { username = item.username, password = item.password, email = item.email,balance = item.balance });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(User request)
        {
            var result = userTransactionServices.CreateUser(request.username, request.password, request.email, request.balance);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(User request)
        {
            var result = userTransactionServices.UpdateUser(request.username, request.password, request.email, request.balance);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteUser(ElysiumApi.User request)
        {

            var userToDelete = new Elysium.User
            {
                username = request.username

            };

            var result = userTransactionServices.DeleteUser(userToDelete);

            return new JsonResult(result);
        }
    }
    }