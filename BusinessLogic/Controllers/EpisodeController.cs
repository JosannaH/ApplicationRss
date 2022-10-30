using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BusinessLogic.Controllers
{
    public class EpisodeController
    {
        FeedController FeedController = new FeedController();
        List<Episode> ListOfEpisodes = new List<Episode>();
        public EpisodeController()
        {
            //FeedController = new FeedController();
            //ListOfEpisodes = new List<Episode>();
        }

        public List<Episode> CreateListOfEpisodes(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
            foreach (var item in syndicationFeed.Items)
            {
                Episode episode = new Episode(item.Title.Text, item.Summary.Text);

                ListOfEpisodes.Add(episode);
            }
            return ListOfEpisodes;
        }

        public string GetDescriptionForEpisode(string feedName, string episodeName)
        {
            Feed feed = FeedController.GetFeedByName(feedName);
            List<Episode> chosenEpisode = feed.ListOfEpisodes.Where(x => x.Name.Equals(episodeName)).ToList();
            string description = chosenEpisode[0].Description;

            return description;
        }
               
    }
}
