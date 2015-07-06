using ConsoleForum.Contracts;
using System.Text;
using System;

namespace ConsoleForum.Entities.Posts
{
    public class BestAnswer : Answer
    {
        public BestAnswer(int id, string body, IUser author)
            :base(id, body, author)
        {
        }


        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format(new string('*', 20)));
            output.AppendLine(base.ToString());
            output.AppendLine(string.Format(new string('*', 20)));
            return output.ToString();
        }
    }
}
