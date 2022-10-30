using Models;
using System.Collections.Generic;
using System.IO;

namespace DataAccess
{
    public class FeedRepository : IRepository<Feed>
    {
        public List<Feed> ListOfFeeds;

        private SerializerForXml SerializerForXml;

        public FeedRepository()
        {
            SerializerForXml = new SerializerForXml();
            ListOfFeeds = new List<Feed>();
        }

        public void Create(Feed feed)
        {
            ListOfFeeds.Add(feed);
            Update();
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
            UpdateListOfFeeds(listOfFeeds);
            Update();
        }

        public bool CheckForFile() { 
        
            return File.Exists("Feeds.xml");
        }

        public void UpdateListOfFeeds(List<Feed> listOfFeeds)
        {
            ListOfFeeds = listOfFeeds;
        }
    }
}
