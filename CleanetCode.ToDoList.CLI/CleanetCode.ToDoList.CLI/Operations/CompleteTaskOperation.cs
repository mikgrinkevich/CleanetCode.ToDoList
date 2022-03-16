using CleanetCode.ToDoList.CLI.Storages;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CompleteTaskOperation : IAuthorizedOperation
    {
        public string Name => "Mark as complete";

        public bool Execute(Guid userId)
        {
            Task[]? tasks = TaskStorage.Get(userId);

            if (tasks == null || tasks.Length == 0)
            {
                Console.WriteLine("No tasks, please, add via menu");
                return true;
            }
            for (var i = 0; i < tasks.Length; i++)
            {
                var task = tasks[i];
                Console.WriteLine($"#{i} - Name: {task.Name}, IsDone: {task.IsCompleted}");
            }

            Console.WriteLine();

            Console.Write("Enter the number of task to execute: ");
            string? userInput = Console.ReadLine();
            bool isNumber = int.TryParse(userInput, out int taskNumber);

            if (!isNumber)
            {
                Console.WriteLine("The number of task is invalid: " + userInput);
                return false;
            }

            Task taskToUpdate = tasks[taskNumber];
            taskToUpdate.IsCompleted = true;

            TaskStorage.Update(userId, taskToUpdate);
            return true;
        }
    }
}
