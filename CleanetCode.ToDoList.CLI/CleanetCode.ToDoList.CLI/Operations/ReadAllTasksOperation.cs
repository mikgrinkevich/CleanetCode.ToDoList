using CleanetCode.ToDoList.CLI.Storages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanetCode.ToDoList.CLI.Operations
{

    public class ReadAllTasksOperation : IOperation
    {
        public string Name => "Show all tasks operation";
        public void Execute()
        {
            if (UserSession.Login)
            {
                TaskStorage.ShowAllTasks();
            }
            else
            {
                Console.WriteLine("Please, login firstly");
            }
        }
    }
}
