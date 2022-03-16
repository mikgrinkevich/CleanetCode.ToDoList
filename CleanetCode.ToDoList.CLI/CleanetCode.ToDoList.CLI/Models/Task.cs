using System;
using CleanetCode.ToDoList.CLI.Operations;
namespace CleanetCode.ToDoList.CLI.Models
{
    public record Task
    {
        private Task()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }

        public (Task? Task, string Error) Update(string? name, string? description)
        {
            var (isValid, error) = Validate(name, description);
            if (!isValid)
            {
                return (null, error);
            }

            Task updatedTask = this with
            {
                Name = name,
                Description = description
            };

            return (updatedTask, String.Empty);
        }

        public static (Task? Task, string Error) Create(string? name, string? description, Guid userId)
        {
            var (isValid, error) = Validate(name, description);
            if (!isValid)
            {
                return (null, error);
            }

            Task task = new Task
            {
                Name = name,
                Description = description,
                UserId = userId
            };

            return (task, String.Empty);
        }
        private static (bool Result, string Error) Validate(string? name, string? description)
        {
            List<string> errors = new();
            if (string.IsNullOrWhiteSpace(name))
            {
                errors.Add("The task name is invalid: " + name);
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                errors.Add("The description is invalid: " + description);
            }

            if (errors.Any())
            {
                return (false, string.Join("\n", errors));
            }

            return (true, String.Empty);
        }

    }
}

