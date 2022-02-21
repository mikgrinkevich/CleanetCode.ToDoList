namespace CleanetCode.ToDoList.CLI.Operations
{
    interface IOperation
    {
        string Name { get; set; }
        void Execute();
    }
}