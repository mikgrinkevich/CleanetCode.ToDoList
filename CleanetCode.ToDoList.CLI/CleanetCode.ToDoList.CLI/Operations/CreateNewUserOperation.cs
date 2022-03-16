using CleanetCode.ToDoList.CLI.Models;
using CleanetCode.ToDoList.CLI.Storages;

namespace CleanetCode.ToDoList.CLI.Operations
{
	public class CreateNewUserOperation : IOperation
	{
		public string Name => "Create new user";

		public bool Execute()
		{
			Console.Write("Enter your email:");
			string? userInput = Console.ReadLine();
			var (email, error) = Email.Create(userInput);
			if (email == null)
			{
				Console.WriteLine(error);
				return false;
			}

			User newUser = new User
			{
				Email = email
			};

			bool userCreated = UserStorage.Create(newUser);
			if (!userCreated)
			{
				Console.WriteLine("The user with this email already exists");
				return false;
			}

			return true;
		}
	}
}

