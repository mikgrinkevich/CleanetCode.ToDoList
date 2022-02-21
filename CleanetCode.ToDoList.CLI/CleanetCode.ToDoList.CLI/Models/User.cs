namespace CleanetCode.ToDoList.CLI.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; } //почему не нужен сеттер????
        public string Email { get; init; } //что такое init и нахой он нужон?
    }
}