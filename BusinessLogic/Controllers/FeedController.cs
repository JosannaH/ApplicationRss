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

namespace BusinessLogic.Controllers
{
    public class FeedController
    {
        FeedRepository FeedRepository = new FeedRepository();
        EpisodeController EpisodeController = new EpisodeController();

        public FeedController()
        {
            //FeedRepository = new FeedRepository();
            //EpisodeController = new EpisodeController();
        }

        public void CreateFeed(string name, string url, string category)
        {
            Feed feed = new Feed(name, url, category);
            feed.ListOfEpisodes = EpisodeController.CreateListOfEpisodes(url);
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
            bool isNew = true;

            List<Episode> ListOfNewEpisodes = new List<Episode>();

            // Loop through list of fetched episodes 
            foreach (var item in syndicationFeed.Items)
            {
                string episodeName = item.Title.Text;

                // Check if episode is already saved
                List<Episode> fetchedEpisode = feed.ListOfEpisodes.Where(x => x.Name.Equals(episodeName)).ToList();
                if (fetchedEpisode.Count > 0) 
                {
                    isNew = false;
                }

                if (isNew)
                {
                    Episode episode = new Episode(item.Title.Text, item.Summary.Text);
                    ListOfNewEpisodes.Add(episode);
                }
            }
            // The new episodes will be first in the list
            List<Episode> UpdatedListOfEpisodes = (List<Episode>)ListOfNewEpisodes.Concat(feed.ListOfEpisodes);
            
            return UpdatedListOfEpisodes;
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
    }
}
