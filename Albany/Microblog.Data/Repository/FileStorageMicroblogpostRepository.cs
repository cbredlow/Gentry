using Microblog.Data.Models.Interfaces;
using Microblog.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Repository
{
    public class FileStorageMicroblogpostRepository : IMicroblogpostRepository
    {
        // Use a single flat csv to store all of the data, can be a list of JSON entries that get converted back into a 

        public void DeleteMicroblogpost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IMicroblogPost> GetMicroblogpost(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IMicroblogPost>> GetMicroblogposts()
        {
            throw new NotImplementedException();
        }

        public Task<int> StoreMicroblogpost(IMicroblogPost postToStore)
        {
            throw new NotImplementedException();
        }
    }
}
