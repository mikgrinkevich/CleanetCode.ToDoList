using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class LoginUserOperation : IOperation
    {
        public string Name => "Login into the system";
        public void Execute()
        {
            Console.Write("Введите email");
            string? email = Console.ReadLine();
            User? user = UserStorage.Get(email);

            if(user != null)
            {
                UserSession.CurrentUser = user;
                UserSession.Login = true;
            }
        }
    }
}
