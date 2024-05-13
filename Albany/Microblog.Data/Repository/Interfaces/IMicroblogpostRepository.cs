using Microblog.Data.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Repository.Interfaces
{
    public interface IMicroblogpostRepository
    {
        Task<IMicroblogPost> GetMicroblogpost(int id);

        Task<IList<IMicroblogPost>> GetMicroblogposts();

        void DeleteMicroblogpost(int id);

        Task<int> StoreMicroblogpost(IMicroblogPost postToStore);

    }
}
