using CleanetCode.ToDoList.CLI.Models;

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
            return _users.TryAdd(user.Email, user); /*
            здесь user уже существующая переменная,которую мы
            возвращаем из другого метода или это новая переменная, которая 
            переменная, которая хранит в себе объект класса с уникальным id guid и email? */
             
            /*можем ли мы дальше юзать эту переменную (user) в другом методе в рамках этого класса или это 
            будет локальная переменная уже*/
        }

    }
}