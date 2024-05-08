using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microblog.Data.Models.Interfaces
{
    public interface IMicroblogPost
    {
        int Id { get; set; }
        string PostString { get; set; }

        DateTime TimePosted { get; set; }
    }
}
