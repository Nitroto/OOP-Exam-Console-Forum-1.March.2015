using System;
using ConsoleForum.Contracts;
using System.Linq;
using ConsoleForum.Entities.Posts;

namespace ConsoleForum.Commands
{
    public class MakeBestAnswerCommand : AbstractCommand
    {
        public MakeBestAnswerCommand(IForum forum)
            : base(forum)
        {
        }


        public override void Execute()
        {
            int answerID = int.Parse(this.Data[1]);
            IAnswer answer;
            var question = this.Forum.CurrentQuestion;
            if (!this.Forum.IsLogged)
            {
                throw new CommandException(Messages.NotLogged);
            }
            if (this.Forum.CurrentQuestion == null)
            {
                throw new CommandException(Messages.NoQuestionOpened);
            }
            if (!question.Answers.Any(a => a.Id == answerID))
            {
                throw new CommandException(Messages.NoAnswer);
            }
            if (question.Author != this.Forum.CurrentUser && !(this.Forum.CurrentUser is IAdministrator))
            {
                throw new CommandException(Messages.NoPermission);
            }
            if (question.Answers.Any(a => a is BestAnswer))
            {
                int currentBestID = question.Answers.Where(a => a is BestAnswer).FirstOrDefault().Id;
                Answer oldBest = new Answer(currentBestID, question.Answers[currentBestID - 1].Body, question.Answers[currentBestID - 1].Author);
                question.Answers[currentBestID - 1] = oldBest;
            }
            answer = question.Answers.Where(a => a.Id == answerID).FirstOrDefault();
            BestAnswer bestAnswer = new BestAnswer(answer.Id, answer.Body, answer.Author);
            question.Answers[answerID - 1] = bestAnswer;
            this.Forum.Output.AppendLine(string.Format(Messages.BestAnswerSuccess,answerID));
        }

    }
}
