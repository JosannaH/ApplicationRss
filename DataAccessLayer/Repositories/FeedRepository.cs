using Models;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;

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

        public bool CheckForFile() { 
        
            return File.Exists("Feeds.xml");
        }
    }
}
