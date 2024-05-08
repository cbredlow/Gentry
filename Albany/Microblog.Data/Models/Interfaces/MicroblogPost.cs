using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Models.Interfaces
{
    public class MicroblogPost : IMicroblogPost
    {
        public int Id { get; set; }
        public string PostString { get; set; }
        public DateTime TimePosted { get; set; }
    }
}
