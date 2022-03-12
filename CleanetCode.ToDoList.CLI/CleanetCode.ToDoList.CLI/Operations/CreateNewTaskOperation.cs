using CleanetCode.ToDoList.CLI.Storages;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewTaskOperation : IOperation
    {
        public string Name => "Create new task";
        public void Execute()
        {
            if (UserSession.Login)
            {
                Console.Write("Enter your task name");
                string? taskName = Console.ReadLine();
                Console.Write("Enter some decription if you need");
                string? description = Console.ReadLine();
                bool isCompleted = false;
                Guid id = Guid.NewGuid();
                Guid userId = Guid.NewGuid();

                Task task = new Task
                {
                    Id = id,
                    Name = taskName,
                    Description = description,
                    IsCompleted = isCompleted,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UserId = UserSession.CurrentUser.Id
                };

                bool isSuccessfullyAdded = TaskStorage.Add(task);
                if (isSuccessfullyAdded)
                {
                    Console.WriteLine("User has been successfully created");
                }
                else
                {
                    Console.WriteLine("Something went wrond, please, try again");
                }
            }
            else
            {
                Console.WriteLine("Please, login before creating new task");
            }

        }
    }
}
