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
        List<Episode> ListOfEpisodes;
        public EpisodeController()
        {
            ListOfEpisodes = new List<Episode>();
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
               
    }
}
