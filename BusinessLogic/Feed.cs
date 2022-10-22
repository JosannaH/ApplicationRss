using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    [Serializable]
    [XmlInclude(typeof(Feed))]
    public class Feed : Entity
    {
        public string Url { get; set; }

        public string Category { get; set; }

        private List<Episode> ListOfEpisodes;
        public int NumberOfEpisodes => ListOfEpisodes.Count();

        public Feed(string name, string url, string category) : base(name)
        {
            Url = url;
            Category = Category;
        }

        public Feed()
        {

        }

      

        public List<Episode> GetListOfEpisodesFromXml()
        {
            return ListOfEpisodes;
        }

        public void SetListOfEpisodesToListView()
        {

        }


    }
}
