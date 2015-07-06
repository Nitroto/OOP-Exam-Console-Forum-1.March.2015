using ConsoleForum.Contracts;
using System.Linq;

namespace ConsoleForum.Commands
{
    class OpenQuestionCommand : AbstractCommand
    {
        public OpenQuestionCommand(IForum forum)
            : base(forum)
        {
        }

        public override void Execute()
        {
            var questions = this.Forum.Questions;
            int qustionId = int.Parse(this.Data[1]);

            if (!questions.Any(q => q.Id == qustionId))
            {
                throw new CommandException(Messages.NoQuestion);
            }
            this.Forum.Output.AppendLine(questions.Where(q => q.Id == qustionId).FirstOrDefault().ToString());
            this.Forum.CurrentQuestion = questions.Where(q => q.Id == qustionId).FirstOrDefault();
        }

    }
}
