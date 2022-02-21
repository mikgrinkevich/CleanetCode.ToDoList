using CleanetCode.ToDoList.CLI.Operations;

namespace CleanetCode.ToDoList.CLI
{
    public class Menu
    {
        //field
        private IOperation[] _operations;
        //constructor
        public Menu(IOperation[] operations)
        {
            _operations = operations;
        }
        //method
        public string[] GetOperationNames()
        {
            List<string> operationNames = new List<string>();

            for (int i = 0; i < _operations.Length; i++)
            {
                IOperation operation = _operations[i];
                operationNames.Add($"{i} - {operation.Name}");
            }

            return operationNames.ToArray();
        }
        public void Enter(int operationNumber)
        {
            if (operationNumber < 0 || operationNumber >= _operations.Length)
            {
                return;
            }

            _operations[operationNumber].Execute();
        }
    }
}