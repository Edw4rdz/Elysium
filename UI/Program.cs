using ElysiumBusinessServices;
namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetServices getServices = new GetServices();


            Console.WriteLine("Welcome!");

            var users = getServices.GetAllUsers();

            foreach (var item in users)
            {
                Console.WriteLine("Username: " + item.username);
                Console.WriteLine("Password: " + item.password);
                Console.WriteLine("Email: " + item.email);
                Console.WriteLine("Remaining Balance: " + item.balance);

            }
        }
    }

}


