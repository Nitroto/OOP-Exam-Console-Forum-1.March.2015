using ConsoleForum.Contracts;

namespace ConsoleForum.Entities.Posts
{
    public abstract class Post : IPost
    {
        private IUser author;
        private string body;
        private int id;


        protected Post()
        {

        }


        public IUser Author
        {
            get
            {
                return this.author;
            }

            set
            {
                // validation
                this.author = value;
            }
        }

        public string Body
        {
            get
            {
                return this.body;
            }

            set
            {
                // validation
                this.body = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            set
            {
                //validation
                this.id = value;
            }
        }
    }
}
