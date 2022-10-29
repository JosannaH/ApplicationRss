using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    public class Episode : Entity
    {
        public string Description { get; set; }
        public Episode(string name, string description) : base(name)
        {
            Description = description;
        }
    }
}
