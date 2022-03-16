using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanetCode.ToDoList.CLI.Operations
{
    public class LogoutUserOperation : IAuthorizedOperation
    {
        public string Name => "Logout";

        public bool Execute(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
