using ConsoleForum.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleForum.Entities.Posts
{
    public class Question : Post, IQuestion
    {
        private IList<IAnswer> answers;
        private string title;


        public Question(int id, string title, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Title = title;
            this.answers = new List<IAnswer>();
            this.Author = author;
        }


        public IList<IAnswer> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                // validation
                this.title = value;
            }
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Question ID: {0} ]", this.Id));
            output.AppendLine(string.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(string.Format("Question Title: {0}", this.Title));
            output.AppendLine(string.Format("Question Body: {0}", this.Body));
            output.AppendLine(new string('=', 20));
            if (this.Answers.Count == 0)
            {
                output.Append("No answers");
            }
            else
            {
                output.AppendLine("Answers:");
                if (this.Answers.Any(a => a is BestAnswer))
                {
                    output.Append(answers.Where(a => a is BestAnswer).FirstOrDefault().ToString());
                }
                foreach (var answer in this.Answers)
                {
                    if (!(answer is BestAnswer))
                    {
                        output.AppendLine(answer.ToString());
                    }
                }
            }
            return RemoveEmptyLines(output.ToString());
        }

        // empty line fix
        private string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n|\r", "", RegexOptions.Multiline).TrimEnd();
        }
    }
}
