﻿namespace CleanetCode.ToDoList.CLI
{
    public class Application
    {
        private readonly Menu _menu;
        public Application(Menu menu)
        {
            _menu = menu;
        }

		public void Run()
		{
			bool userQuit = false;

			while (!userQuit)
			{
				List<string> operationNames = new List<string>();
				operationNames.Add("q - выйти из программы");
				operationNames.AddRange(_menu.GetOperationNames());


				Console.WriteLine(string.Join("\n", operationNames));
				Console.Write("Введите номер операции: ");

				string? userInput = Console.ReadLine();
				if (userInput != null && userInput.Trim().ToLower() == "q")
				{
					userQuit = true;
				}

				bool isNumber = int.TryParse(userInput, out int operationNumber);
				if (isNumber)
				{
					_menu.Enter(operationNumber);
				}
			}
		}
	}
}