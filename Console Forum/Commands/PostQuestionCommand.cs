using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    class PostQuestionCommand : AbstractCommand
    {
        public PostQuestionCommand(IForum forum)
            : base(forum)
        {
        }


        public override void Execute()
        {
            var questions = this.Forum.Questions;

            string title = this.Data[1];
            string body = this.Data[2];

            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }

            Question question = new Question((questions.Count + 1), title, body, this.Forum.CurrentUser);
            questions.Add(question);
            this.Forum.Output.AppendLine(string.Format(Messages.PostQuestionSuccess, question.Id));
        }
    }
}
