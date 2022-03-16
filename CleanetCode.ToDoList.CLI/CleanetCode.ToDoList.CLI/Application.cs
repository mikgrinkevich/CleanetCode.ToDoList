namespace CleanetCode.ToDoList.CLI
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
			const string quitKey = "q";

			while (!userQuit)
			{
				List<string> operationNames = new List<string>();
				operationNames.Add(quitKey +" - quit");
				operationNames.AddRange(_menu.GetOperationNames());

				Console.WriteLine(string.Join("\n", operationNames));
				Console.Write("Enter operation number: ");

				string? userInput = Console.ReadLine();
				if (userInput != null && userInput.Trim().ToLower() == "q")
				{
					userQuit = true;
				}

				bool isNumber = int.TryParse(userInput, out int operationNumber);
				if (isNumber)
				{
					Console.Clear();
					var (isSuccess, error) = _menu.Enter(operationNumber);

					Console.WriteLine(isSuccess ? "Operation was completed successfully" : error);
				}
                else
                {
					Console.WriteLine("Your input is not a number: " + userInput);
				}

				Console.WriteLine("Press any key to continue");
				Console.ReadKey(true);
				Console.Clear();
			}
		}
	}
}