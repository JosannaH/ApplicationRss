using DataAccess;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.ServiceModel.Syndication;
using System.Xml;
using BusinessLogic.Exceptions;
using System;

namespace BusinessLogic.Controllers
{
    public class FeedController : EntityController<Feed>
    {
        private FeedRepository FeedRepository;
        private Validator FeedValidator;
        private MessageCreator MessageCreator;
        public FeedController()
        {
            FeedRepository = new FeedRepository();
            FeedValidator = new Validator();
            MessageCreator = new MessageCreator();
        }

        override
        public bool Create(string name, string url, string category)
        {
            bool success = false;
            string errorMessage = FeedValidator.ErrorMessageCreateFeed(name, url, category, FeedRepository.ListOfFeeds);
           
            if (string.IsNullOrEmpty(errorMessage)) // empty error message = feed can be created
            {
                Feed feed = new Feed(name, url, category);
                feed.ListOfEpisodes = CreateListOfEpisodes(url);
                FeedRepository.Create(feed);

                success = true;
             }
             else
             {
                 MessageCreator.ShowMessage(errorMessage);    
             }
            return success;
        }

        override
        public List<Feed> ReadListFromFile()
        {
            return FeedRepository.Read();
        }

        override
        public bool Update(string chosenFeed, string newName, string newUrl, string newCategory)
        {
            bool success = false;
            string errorMessage = FeedValidator.ErrorMessageUpdateFeed(newName, newUrl, newCategory, FeedRepository.ListOfFeeds);
            Feed feed;
            List<Feed> feedToEdit = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(chosenFeed)).ToList();
            try
            {
                feed = feedToEdit[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Could not find feed to update.");
            }
            

            if (string.IsNullOrEmpty(errorMessage))
            {
                feed.ListOfEpisodes = CreateListOfEpisodes(newUrl);
                feed.Name = newName;
                feed.Url = newUrl;
                feed.Category = newCategory;
                FeedRepository.Update();

                success = true;
            }
            else
            {
                MessageCreator.ShowMessage(errorMessage);
            }
            return success;
        }

        override
        public void Delete(string feedToDelete)
        {
            List<Feed> updatedList = FeedRepository.ListOfFeeds.Where(x => x.Name != feedToDelete).ToList();
            FeedRepository.Delete(updatedList);
        }

        public Feed GetFeedByName(string feedName)
        {
            List<Feed> chosenFeed = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(feedName)).ToList();
            Feed feed;
            try
            {
                feed = chosenFeed[0];
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Can not find chosen feed.");
            }
            
            return feed;
        }

        public List<Episode> GetListOfEpisodesForFeed(string feedName)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

                List<Feed> feed = FeedRepository.ListOfFeeds.Where(x => x.Name.Equals(feedName)).ToList();
            try
            {
                listOfEpisodes = feed[0].ListOfEpisodes;
            }
            catch (IndexOutOfRangeException)
            {
                throw new IndexOutOfRangeException("Could not find feed.");
            }
            return listOfEpisodes;
        }

        public List<Feed> GetListOfAllFeeds()
        {
            return FeedRepository.ListOfFeeds;
        }

        public List<Episode> UpdateEpisodesForOneFeed(Feed feed)
        {
            SyndicationFeed syndicationFeed;
            try
            {
                XmlReader xmlReader = XmlReader.Create(feed.Url);
                syndicationFeed = SyndicationFeed.Load(xmlReader);
            }
            catch (Exception)
            {
                throw new Exception("Could not get xml file from url.");
            }

            List<Episode> listOfNewEpisodes = new List<Episode>();

            foreach (var item in syndicationFeed.Items)
            {
                string episodeName = item.Title.Text;

                if(FeedValidator.IsUniqueEpisode(episodeName, feed))
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
            return updatedListOfEpisodes;
        }

        public void UpdateEpisodesForAllFeeds(List<Feed> listOfFeeds)
        {
            foreach (Feed feed in listOfFeeds)
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

        override
        public bool FileExists()
        {
            return FeedRepository.CheckForFile();
        }

        public List<Episode> CreateListOfEpisodes(string url)
        {
            List<Episode> listOfEpisodes = new List<Episode>();
            SyndicationFeed syndicationFeed;
            try
            {
                XmlReader xmlReader = XmlReader.Create(url);
                syndicationFeed = SyndicationFeed.Load(xmlReader);
            }
            catch
            {
                throw new InvalidUrlException("Invalid URL.");
            }

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
