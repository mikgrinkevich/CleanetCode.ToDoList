using CleanetCode.ToDoList.CLI.Models;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class CreateNewTaskOperation : IOperation
    {
        public string Name { get; }
        public void Execute()
        {
            //в моделе юзера, у нас каждый пользователь как бы уникальный, поэтому там есть только сеттер
            //но в задаче у нас есть еще и геттер - чтобы понимать, какому юзеру принадлежит задача?

            //соответственно когда мы создавали юзера гуид автоматически создавался сам в конструкторе
            //здесь нужна какая-то дополнительная логика, раз по умолчанию у нас это не так?
            
            //типо нужно создать параметры для конструктора и присвоить их полям класса
            Console.Write("Enter your task name");
            string? task_name = Console.ReadLine();
            Console.Write("Enter some deccription if you need");
            string? description = Console.ReadLine();
            bool is_completed = false;
            DateTime created_date = DateTime.Now;
            DateTime updated_date = DateTime.Now;
            Guid user_id = new Guid();

            //чтобы создать новую таску мне нужно объявить все поля, что есть в моделях?
            Task task = new Task(string task_name, string description, bool is_completed,
                DateTime created_date, DateTime updated_date, Guid user_id)
            {
                //this.Id = id; //а гуид приватное поле, значит надо его создавать внутри класса, а как
                this.Name = task_name;
                this.Description = description;
                this.IsCompleted = is_completed;
                this.CreatedDate = created_date;
                this.UpdatedDate = updated_date;
                this.UserId = user_id;
            } 
           
        }
    }
}
