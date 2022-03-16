using CleanetCode.ToDoList.CLI.Models;

namespace CleanetCode.ToDoList.CLI
{
    public static class UserSession
    {
        public static User? CurrentUser { get; set; }
    }
}