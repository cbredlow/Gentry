using Microblog.Data.Models.Interfaces;
using Microblog.Data.Repository.Interfaces;
using Microblog.Data.Services.Interfaces;

namespace Microblog.Data.Services
{
    public  class MicroblogpostService : IMicroblogpostService
    {

        Dictionary<int, IMicroblogPost> posts;
        IMicroblogpostRepository microblogpostRepository;


        public MicroblogpostService(IMicroblogpostRepository repository)
        {
            this.posts = new Dictionary<int, IMicroblogPost>();
            this.microblogpostRepository = repository;
        }


        public async Task<int> CreateMicroblogPost(string postData)
        {
            var blogPost = new MicroblogPost
            {
                Id = 0,
                TimePosted = DateTime.Now,
                PostString = postData
            };

            int id = await this.microblogpostRepository.StoreMicroblogpost(blogPost).ConfigureAwait(false);

            blogPost.Id = id;
            this.posts[id] = blogPost;
            return id;

        }

        public async Task<IMicroblogPost> GetMicroblogPost(int id)
        {
            if(posts.ContainsKey(id))
            {
                return posts[id];
            }

            var post = await this.microblogpostRepository.GetMicroblogpost(id).ConfigureAwait(false);
            if (post != null)
            {
                return post;
            }
            else
            {
                throw new Exception("No such post exists");
            }
        }

        public async Task<IList<IMicroblogPost>> GetAllMicroblogPosts()
        {
            try
            {
                var postList = await this.microblogpostRepository.GetMicroblogposts().ConfigureAwait(false);
                if( postList != null)
                {
                    return postList;
                }
                throw new Exception("No posts");
            }catch (Exception ex)
            {
                throw new Exception("No posts to return");
            }
        }

        public void DeleteMicroblogPost(int id)
        {
            if(posts.ContainsKey(id))
            {
                posts.Remove(id);
            }
            try
            {
                this.microblogpostRepository.DeleteMicroblogpost(id);
            }catch (Exception ex)
            {
                throw new Exception("No such post exists");
            }
        }
    }
}
