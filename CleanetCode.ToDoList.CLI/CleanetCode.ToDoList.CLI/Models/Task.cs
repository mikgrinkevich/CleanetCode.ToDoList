using System;
using CleanetCode.ToDoList.CLI.Operations;
namespace CleanetCode.ToDoList.CLI.Models
{
    public class Task
    {
        public Task(string name, string description, bool is_completed, Guid id)
        {
            this.Name = name;
            this.Description = description;
            this.IsCompleted = is_completed;
            this.Id = id;
        }
        private Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserId { get; set; }

    }
}

