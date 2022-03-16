using CleanetCode.ToDoList.CLI.Operations;
using Task = CleanetCode.ToDoList.CLI.Models.Task;

namespace CleanetCode.ToDoList.CLI.Storages
{
    public static class TaskStorage
    {
        private static readonly Dictionary<Guid, List<Task>> _tasks = new ();

        public static Task[]? Get(Guid userId)
        {
            _tasks.TryGetValue(userId, out List<Task>? tasks);
            return tasks?.ToArray();
        }

        public static void Add(Task task)
        {
            _tasks.TryGetValue(task.UserId, out List<Task>? tasks);
            if (tasks == null)
            {
                _tasks.Add(task.UserId, new List<Task>{ task});
            }
            else
            {
                tasks.Add(task);
            }
        }

        public static void Remove(Guid userId, Guid taskId)
        {
            _tasks.TryGetValue(userId,out List<Task>? tasks);
            if (tasks == null)
            {
                return;
            }

            Task taskToDelete = null;
            foreach (var task in tasks)
            {
                if (task.Id == taskId)
                {
                    taskToDelete = task;
                }
            }

            if (taskToDelete == null)
            {
                return ;
            }

            tasks.Remove(taskToDelete);
        }

        public static void Update(Guid userId, Task updatedTask)
        {
            _tasks.TryGetValue(userId, out List<Task>? tasks);
            if (tasks == null)
            {
                return;
            }

            Task taskToUpdate = null;
            foreach (var task in tasks)
            {
                if (task.Id == updatedTask.Id)
                {
                    taskToUpdate = task;
                }
            }

            if (taskToUpdate == null)
            {
                return;
            }

            tasks.Remove(taskToUpdate);
            tasks.Add(updatedTask);

        }
    }
}
