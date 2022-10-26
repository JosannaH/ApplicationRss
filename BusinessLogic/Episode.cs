using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{
    [Serializable]
    public class Episode : Entity
    {
        public string Description { get; set; }
        public Episode()
        {

        }
    }
}
