using ConsoleForum.Contracts;
using ConsoleForum.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleForum.Commands
{
    class PostAnswerCommand : AbstractCommand
    {
        public PostAnswerCommand(IForum forum)
            : base(forum)
        {
        }


        public override void Execute()
        {
            string body = this.Data[1];
            var question = this.Forum.CurrentQuestion;
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            var answer = new Answer(this.Forum.Answers.Count + 1, body, this.Forum.CurrentUser);
            this.Forum.Answers.Add(answer);
            question.Answers.Add(answer);
            this.Forum.Output.AppendLine(string.Format(Messages.PostAnswerSuccess, answer.Id));
        }
    }
}
