using ConsoleForum.Contracts;
using ConsoleForum.Utility;
using System.Linq;

namespace ConsoleForum.Commands
{
    class LoginCommand : AbstractCommand
    {
        public LoginCommand(IForum forum)
            : base(forum)
        {
        }


        public override void Execute()
        {
            var users = this.Forum.Users;
            string username = this.Data[1];
            string password = PasswordUtility.Hash(this.Data[2]);

            if (this.Forum.IsLogged)
            {
                throw new CommandException(Messages.AlreadyLoggedIn);
            }
            if (users.Where(u => u.Username == username && u.Password == password).Count() == 0)
            {
                throw new CommandException(Messages.InvalidLoginDetails);
            }
            this.Forum.CurrentUser = users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
            this.Forum.Output.AppendLine(string.Format(Messages.LoginSuccess, this.Forum.CurrentUser.Username));
        }
    }
}
