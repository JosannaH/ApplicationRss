using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Security.Policy;
using System.Xml.Linq;

namespace BusinessLogic.Controllers
{
    public class FeedController
    {
        FeedRepository FeedRepository;
        EpisodeController EpisodeController;

        public FeedController()
        {
            FeedRepository = new FeedRepository();
            EpisodeController = new EpisodeController();
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

    

    }
}
