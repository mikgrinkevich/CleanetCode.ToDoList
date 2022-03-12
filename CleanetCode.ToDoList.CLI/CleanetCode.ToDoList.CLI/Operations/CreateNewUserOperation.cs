using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewUserOperation : IOperation
    {
        public string Name => "Create new user";
        public void Execute()
        {
            Console.Write("Enter your email: ");
            string? email = Console.ReadLine();

            //т.е как только в конструктор попадает это свойство, мы создаем объект класса
            User newUser = new User
            {
                Email = email,
            };

            bool UserCreated = UserStorage.Create(newUser);
            if (UserCreated)
            {
                Console.WriteLine("You've successfully created a new user");
            }
            else
            {
                Console.WriteLine("The user is already exist");
            }
            /*if (UserCreated)
            {
                var test = UserStorage.Save(newUser);
                Console.WriteLine("You've successfully created a new user");
            }
            else
            {
                Console.WriteLine("The user is already exist");
            }
            */
        }
    }
}

