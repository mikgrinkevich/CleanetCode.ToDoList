using CleanetCode.ToDoList.CLI.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Operations
{

    public class ReadAllTasksOperation : IAuthorizedOperation
    {
        private readonly Menu _menu;

        public ReadAllTasksOperation(Menu menu)
        {
            _menu = menu;
        }

        public string Name => "View the list of tasks";

        public bool Execute(Guid userId)
        {
            bool userQuit = false;
            const string quitKey = "q";

            while (!userQuit)
            {
                Task[]? tasks = TaskStorage.Get(userId);

                if (tasks == null || tasks.Length == 0)
                {
                    Console.WriteLine("No tasks, add via menu");
                }
                else
                {
                    foreach (var task in tasks)
                    {
                        Console.WriteLine(
                            $"Id: {task.Id}, Name: {task.Name}, Description: {task.Description}, IsDone: {task.IsCompleted}");
                    }

                    Console.WriteLine();
                }

                List<string> operationNames = new List<string>();
                operationNames.Add(quitKey + " - go back");
                operationNames.AddRange(_menu.GetOperationNames());

                Console.WriteLine(string.Join("\n", operationNames));
                Console.Write("Enter number of operation: ");

                string? userInput = Console.ReadLine();
                if (userInput != null && userInput.Trim().ToLower() == quitKey)
                {
                    userQuit = true;
                    continue;
                }

                bool isNumber = int.TryParse(userInput, out int operationNumber);
                if (isNumber)
                {
                    Console.Clear();
                    var (isSuccess, error) = _menu.Enter(operationNumber);

                    Console.WriteLine(isSuccess ? "Task was executed successfully" : error);
                }
                else
                {
                    Console.WriteLine("Your input is not a number: " + userInput);
                }

                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
            }

            return true;
        }
    }
}
