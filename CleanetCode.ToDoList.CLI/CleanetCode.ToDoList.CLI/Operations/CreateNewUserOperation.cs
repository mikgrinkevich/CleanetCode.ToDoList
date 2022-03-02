using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewUserOperation : IOperation
    {
        public string Name => "Create new user";
        public void Execute()
        {
            Console.Write("Enter your email");
            string? email = Console.ReadLine();

            User newUser = new User
            {
                Email = email,
            };
            bool UserCreated = UserStorage.Create(newUser);
            if (!UserCreated)
            {
                Console.WriteLine("Пользователь с таким email уже есть");
            }

            Console.WriteLine("You've successfully created a new user");

            FileStream userFile = new FileStream("C:\\Dev\\userData.txt", 
                FileMode.OpenOrCreate, FileAccess.ReadWrite);
            User userData = UserStorage.Get(); /*насколько я понимаю, имплементация должна быть 
            именно тут, но я не понимаю, какой параметр сюда предавать и откуда его взять*/
            userFile.Write(userData);
            userFile.Close();
        }
    }
}

