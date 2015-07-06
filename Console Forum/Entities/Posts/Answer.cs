using ConsoleForum.Contracts;
using System;
using System.Text;

namespace ConsoleForum.Entities.Posts
{
    public class Answer : Post, IAnswer
        {

        public Answer(int id, string body, IUser author)
        {
            this.Id = id;
            this.Body = body;
            this.Author = author;
        }
        

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("[ Answer ID: {0} ]", this.Id));
            output.AppendLine(string.Format("Posted by: {0}", this.Author.Username));
            output.AppendLine(string.Format("Answer Body: {0}", this.Body));
            output.Append(new string('-', 20));
            return output.ToString();
        }
    }
}
