using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class LoginUserOperation : IOperation
    {
        public string Name => "Login into the system";

        public bool Execute()
        {
            Console.Write("Enter your email:");
            string? userInput = Console.ReadLine();
            var (email, error) = Email.Create(userInput);
            if (email == null)
            {
                Console.WriteLine(error);
                return false;
            }

            User? user = UserStorage.Get(email);
            if (user == null)
            {
                Console.WriteLine("User was not found");
                return false;
            }

            UserSession.CurrentUser = user;
            return true;
        }
    }
}
