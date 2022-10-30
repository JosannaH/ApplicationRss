using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Security.Policy;
using System.Xml.Linq;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;

namespace BusinessLogic.Controllers
{
    //[Serializable]
    //[XmlInclude(typeof(FeedController))]
    public class FeedController
    {
         FeedRepository FeedRepository;

        public FeedController()
        {
            FeedRepository = new FeedRepository();
        }

        public void CreateFeed(string name, string url, string category)
        {
            Feed feed = new Feed(name, url, category);
            feed.ListOfEpisodes = CreateListOfEpisodes(url);
            FeedRepository.Create(feed);
        }

        public List<Feed> ReadListOfFeedsFromFile()
        {
            return FeedRepository.Read();
        }

        public void UpdateFeed(string chosenFeed, string newName, string newUrl, string newCategory)
        {
            List<Feed> feedToEdit = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(chosenFeed)).ToList();
            feedToEdit[0].Name = newName;
            feedToEdit[0].Url = newUrl;
            feedToEdit[0].Category = newCategory;
            FeedRepository.Update();
        }

        public void DeleteFeed(string feedToDelete)
        {
            List<Feed> updatedList = FeedRepository.ListOfFeeds.Where(x => x.Name != feedToDelete).ToList();
            FeedRepository.Delete(updatedList);
        }

        public Feed GetFeedByName(string feedName)
        {
            List<Feed> chosenFeed = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(feedName)).ToList();
            Feed feed = chosenFeed[0];
            return feed;
        }

        public List<Episode> GetListOfEpisodesForFeed(string feedName)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            if (feedName != null)
            {
                List<Feed> feed = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(feedName)).ToList();
                listOfEpisodes = feed[0].ListOfEpisodes;
            }
            return listOfEpisodes;
        }

        public List<Feed> GetListOfAllFeeds()
        {
            return FeedRepository.ListOfFeeds;
        }

        public List<Episode> UpdateEpisodesForOneFeed(Feed feed)
        {
            // TODO: XmlException 
            XmlReader xmlReader = XmlReader.Create(feed.Url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);

            List<Episode> listOfNewEpisodes = new List<Episode>();

            // Loop through list of fetched episodes 
            foreach (var item in syndicationFeed.Items)
            {
                string episodeName = item.Title.Text;

                // Check if episode is already saved
                List<Episode> duplicateEpisode = feed.ListOfEpisodes.Where(x => x.Name.Equals(episodeName)).ToList();
               
                if ((duplicateEpisode != null) && (!duplicateEpisode.Any())) // if not already saved
                {
                    Episode episode = new Episode(item.Title.Text, item.Summary.Text);
                    listOfNewEpisodes.Add(episode);
                }
            
            }
            List<Episode> updatedListOfEpisodes = new List<Episode>();

            // The new episodes will be first in the list
            if ((updatedListOfEpisodes != null) && (!updatedListOfEpisodes.Any()))
            {

                updatedListOfEpisodes = listOfNewEpisodes.Concat(feed.ListOfEpisodes).ToList();
            }
            //List<Episode> UpdatedListOfEpisodes = listOfNewEpisodes.AddRange(feed.ListOfEpisodes);
            
            return updatedListOfEpisodes;
        }

        public void UpdateEpisodesForAllFeeds(List<Feed> listOfFeeds)
        {
            foreach (Feed feed in FeedRepository.ListOfFeeds)
            {
                feed.ListOfEpisodes = UpdateEpisodesForOneFeed(feed);
            }
            FeedRepository.Update();
        }

        public void UpdateCategoryForFeeds(string oldCategory, string newCategory)
        {

            List<Feed> feedsWithCategory = FeedRepository.ListOfFeeds.Where(x => x.Category.Equals(oldCategory)).ToList();

            foreach (Feed feed in feedsWithCategory)
            {
                feed.Category = newCategory;
            }
            FeedRepository.Update();
            FeedRepository.Read();
        }

        public void DeleteFeedsWithCategory(string category)
        {
            FeedRepository.ListOfFeeds = FeedRepository.ListOfFeeds.Where(x => x.Category != category).ToList();
            FeedRepository.Update();
        }

        public List<Feed> SortFeedsByCategory(string category)
        {
            List<Feed> ListOfSortedFeeds = GetListOfAllFeeds().Where(x => x.Category.Equals(category)).ToList();
            return ListOfSortedFeeds;
        }

        public bool FileOfFeedsExists()
        {
            return FeedRepository.CheckForFile();
        }

        public List<Episode> CreateListOfEpisodes(string url)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);

            foreach (var item in syndicationFeed.Items)
            {
                Episode episode = new Episode(item.Title.Text, item.Summary.Text);

                listOfEpisodes.Add(episode);
            }
            return listOfEpisodes;
        }

        public string GetDescriptionForEpisode(string feedName, string episodeName)
        {
            Feed feed = GetFeedByName(feedName);
            List<Episode> chosenEpisode = feed.ListOfEpisodes.Where(x => x.Name.Equals(episodeName)).ToList();
            string description = chosenEpisode[0].Description;

            return description;
        }
    }
}
