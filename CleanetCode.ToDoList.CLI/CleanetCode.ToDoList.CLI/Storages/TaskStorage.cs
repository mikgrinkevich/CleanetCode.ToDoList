using CleanetCode.ToDoList.CLI.Operations;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Storages
{
    public class TaskStorage
    {
        private static readonly List<Task> _tasks = new();

        private static List<Task> Get()
        {
            return _tasks;
        }

        public static bool Add(Task task)
        {
            _tasks.Add(task);
            return true;
        }

        public static void ShowAllTasks()
        {
            List<string> taskNames = new List<string>();
            if(_tasks.Count > 0)
            {
                Console.Clear();
                Console.WriteLine("The list of all operations: ");
                foreach (var _task in _tasks)
                {
                    taskNames.Add(_task.Name);
                }
                foreach (var taskName in taskNames)
                {
                    Console.WriteLine(taskName);
                }
            }
            else
            {
                Console.WriteLine("There are no any tasks");
            }
        }
    }
}
