using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public interface IFeedRepository<Feed> : IRepository<Feed>    
    {
        void Update(Feed feed);
        void Delete(Feed feed);
    }
}
