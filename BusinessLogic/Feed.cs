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
        public int UpdateInterval { get; set; }

        private List<Episode> ListOfEpisodes;
        public int NumberOfEpisodes => ListOfEpisodes.Count();

        private int lastUsedId = 0;


        public Feed(string name, string url, int updateInterval, string category) : base(name)
        {
            Url = url;
            UpdateInterval = updateInterval;
            base.Id = lastUsedId + 1;
            lastUsedId = base.Id;
            // add to categorylist
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
