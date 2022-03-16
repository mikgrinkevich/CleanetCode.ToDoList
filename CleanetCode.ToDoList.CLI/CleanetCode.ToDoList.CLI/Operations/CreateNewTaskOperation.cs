using CleanetCode.ToDoList.CLI.Storages;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewTaskOperation : IAuthorizedOperation
    {
        public string Name => "Create a new task";

        public bool Execute(Guid userId)
        {
            Console.Write("Please, enter name of the task: ");
            string? name = Console.ReadLine();

            Console.Write("Please, enter description of the task: ");
            string? description = Console.ReadLine();

            var (newTask, error) = Task.Create(name, description, userId);

            if (newTask == null)
            {
                Console.WriteLine(error);
                return false;
            }

            TaskStorage.Add(newTask);

            return true;
        }
    }
}
