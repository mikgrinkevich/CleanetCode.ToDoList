﻿namespace CleanetCode.ToDoList.CLI.Operations
{
    public interface IOperation
    {
        string Name { get; }
        bool Execute();
    }
}