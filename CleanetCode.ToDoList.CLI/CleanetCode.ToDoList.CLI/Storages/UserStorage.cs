using CleanetCode.ToDoList.CLI.Models;

namespace CleanetCode.ToDoList.CLI.Storages
{
    public static class UserStorage
    {
        private static readonly Dictionary<Email, User> _users = new();

        public static User? Get(Email email)
        {
            _users.TryGetValue(email, out User? user);
            return user; 
        }

        public static bool Create(User user) 
        {
            return _users.TryAdd(user.Email, user);
        }
    }
}