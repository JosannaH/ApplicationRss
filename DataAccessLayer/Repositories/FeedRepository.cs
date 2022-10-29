using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess
{
    public class FeedRepository : IRepository<Feed>
    {
        SerializerForXml SerializerForXml;
        public List<Feed> ListOfFeeds { get; set; }    

        public FeedRepository()
        {
            SerializerForXml = new SerializerForXml();
           
        }
        public void Create(Feed feed)
        {
            ListOfFeeds.Add(feed);
            SerializerForXml.SerializeFeed(ListOfFeeds);
        }

        public List<Feed> Read()
        {
            ListOfFeeds = SerializerForXml.DeserializeFeed();
            return ListOfFeeds;
        }

        public void Update()
        {
            SerializerForXml.SerializeFeed(ListOfFeeds);
        }

        public void Delete(List<Feed> listOfFeeds)
        {
            ListOfFeeds = listOfFeeds;
            SerializerForXml.SerializeFeed(ListOfFeeds);
        }


    }
}
