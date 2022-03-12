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
    }
}
