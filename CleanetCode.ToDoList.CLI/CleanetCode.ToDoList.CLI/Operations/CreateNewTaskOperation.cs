using CleanetCode.ToDoList.CLI.Models;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewTaskOperation : IOperation
    {
        public string Name => "Create new task";
        public void Execute()
        {
            Console.Write("Enter your task name");
            string task_name = Console.ReadLine();
            Console.Write("Enter some decription if you need");
            string description = Console.ReadLine();
            bool is_completed = false;
            Guid id = new Guid();

            /*
            DateTime created_date = DateTime.Now;
            DateTime updated_date = DateTime.Now;
            Guid user_id = new Guid();
            */
            Task task = new Task
            {
                Name = task_name,
                Description = description,
                IsCompleted = is_completed,
                Id = id
            };

        }
    }
}
