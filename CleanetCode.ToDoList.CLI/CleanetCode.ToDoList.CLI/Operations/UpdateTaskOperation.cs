using CleanetCode.ToDoList.CLI.Storages;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class UpdateTaskOperation : IAuthorizedOperation
    {
        public string Name => "Update task";

        public bool Execute(Guid userId)
        {
            Task[]? tasks = TaskStorage.Get(userId);

            if (tasks == null || tasks.Length == 0)
            {
                Console.WriteLine("No tasks add via menu");
                return true;
            }

            for (var i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"#{i} - Name: {task.Name}, IsDone: {task.IsCompleted}");
            }

            Console.WriteLine();

            Console.Write("Enter number of the task to be done: ");
            string? userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int taskNumber);

            if (!isNumber)
            {
                Console.WriteLine("Tsk number is invalid: " + userInput);
                return false;
            }

            Task taskToUpdate = tasks[taskNumber];

            Console.Write("Enter task name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter task description: ");
            string? description = Console.ReadLine();

            var (updatedTask, error) = taskToUpdate.Update(name, description);

            if (updatedTask == null)
            {
                Console.WriteLine(error);
                return false;
            }

            TaskStorage.Update(userId, updatedTask);
            return true;
        }
    }
}
