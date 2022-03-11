using CleanetCode.ToDoList.CLI.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace CleanetCode.ToDoList.CLI.Storages
{
    public static class UserStorage
    {
        private static readonly Dictionary<string, User> _users = new();
        public static User? Get(string email)
        {
            _users.TryGetValue(email, out User? user);
            return user; //здеся user же тоже локальный?
        }

        public static bool Create(User user) //верно ли что мы здесь создаем объект класса?
        {
            return _users.TryAdd(user.Email, user);
        }

        public static string Save(User user)
        {
            using (StreamWriter file = new StreamWriter("C:\\dev\\users.txt"))
                foreach (var item in _users)
                    file.WriteLine("[{0} {1}]", item.Key, item.Value);
            return null;
        }

    }
}