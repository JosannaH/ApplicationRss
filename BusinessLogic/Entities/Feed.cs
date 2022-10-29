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

        public List<Episode> ListOfEpisodes { get; set; }
        public int NumberOfEpisodes => ListOfEpisodes.Count();

        public Feed(string name, string url, string category, List<Episode> listOfEpisodes) : base(name)
        {
            Url = url;
            Category = category;
            ListOfEpisodes = listOfEpisodes;
        }
        public Feed(string name, string url, string category) : base(name)
        {
            Url = url;
            Category = category;
        }

        public Feed()
        {

        }
    }
}
