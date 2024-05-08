using Microblog.Data.Models.Interfaces;
using Microblog.Data.Services.Interfaces;

namespace Microblog.Data.Services
{
    public  class MicroblogpostService : IMicroblogpostService
    {

        Dictionary<int, IMicroblogPost> posts;

        public MicroblogpostService()
        {
            this.posts = new Dictionary<int, IMicroblogPost>();
        }


        public int CreateMicroblogPost(string postData)
        {
            int id = this.posts.Keys.Count+1; //get the next entry, prevents post 0 from happening
            var blogPost = new MicroblogPost
            {
                Id = id,
                TimePosted = DateTime.Now,
                PostString = postData
            };

            this.posts[id] = blogPost;
            return id;

        }

        public IMicroblogPost GetMicroblogPost(int id)
        {
            if(this.posts.ContainsKey(id))
                return this.posts[id];
            throw new Exception("No such post exists");
        }

        public IList<IMicroblogPost> GetAllMicroblogPosts()
        {
            if (posts.Count > 0)
            {
                return posts.Values.ToList();
            }
            throw new Exception("No posts to return");
        }

        public void DeleteMicroblogPost(int id)
        {
            if(posts.ContainsKey(id))
            {
                posts.Remove(id);
                return;
            }

            throw new Exception("No such post exists");
        }
    }
}
