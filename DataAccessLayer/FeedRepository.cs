using ApplicationRss;
using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class FeedRepository : IFeedRepository<Feed>
    {
        SerializerForXml serializerForXml;
        List<Feed> ListOfFeeds;
        public void Create(Feed entity)
        {

            throw new NotImplementedException();
        }

        public void Delete(Feed feed)
        {
            throw new NotImplementedException();
        }

        public List<Feed> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Feed feed)
        {
            throw new NotImplementedException();
        }
    }
}
