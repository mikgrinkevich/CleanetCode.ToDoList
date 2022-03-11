﻿using System;
using CleanetCode.ToDoList.CLI.Operations;
namespace CleanetCode.ToDoList.CLI.Models
{
    public class Task
    {

        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid UserId { get; set; }

    }
}

