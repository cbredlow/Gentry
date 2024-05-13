using Microblog.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Services.Interfaces
{
    public interface IMicroblogpostService
    {
        /// <summary>
        /// Creates a Microblog post
        /// </summary>
        /// <param name="postData">string content of the post</param>
        /// <returns></returns>
        Task<int> CreateMicroblogPost(string postData);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IMicroblogPost> GetMicroblogPost(int id);

        Task<IList<IMicroblogPost>> GetAllMicroblogPosts();

        void DeleteMicroblogPost(int id);

    }
}
