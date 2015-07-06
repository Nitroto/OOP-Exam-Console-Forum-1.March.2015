using ConsoleForum.Contracts;

namespace ConsoleForum.Commands
{
    class ShowQuestionsCommand : AbstractCommand
    {
        public ShowQuestionsCommand(IForum forum)
            : base(forum)
        {
        }


        public override void Execute()
        {
            this.Forum.CurrentQuestion = null;
            if (this.Forum.Questions.Count == 0)
            {
                this.Forum.Output.AppendLine(Messages.NoQuestions);
            }
            else
            {
                foreach (var question in this.Forum.Questions)
                {
                    this.Forum.Output.AppendLine(question.ToString());
                }
            }
        }
    }
}
