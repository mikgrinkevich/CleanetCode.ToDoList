using CleanetCode.ToDoList.CLI.Storages;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class DeleteTaskOperation : IAuthorizedOperation
    {
        public string Name => "Delete task";

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

            Console.Write("Enter the number of task to delete: ");
            string? userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int taskNumber);

            if (!isNumber)
            {
                Console.WriteLine("Wrong task number: " + userInput);
                return false;
            }

            Task taskToDelete = tasks[taskNumber];
            TaskStorage.Remove(userId, taskToDelete.Id);
            return true;
        }
    }
}
