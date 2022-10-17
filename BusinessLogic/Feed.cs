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
    public class Feed
    {
        // TODO: shouldn't properties be private??

        // public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int UpdateInterval { get; set; }
        //public Category Category { get; set; }
        //public List<Episode> ListOfEpisodes { get; set; }
        public int NumberOfEpisodes { get; set; }

      


    }
}
