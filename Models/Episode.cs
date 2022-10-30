using System;
using System.Xml.Serialization;

namespace Models
{
    [Serializable]
    [XmlInclude(typeof(Episode))]
    public class Episode : Entity
    {
        public string Description { get; set; }
        public Episode(string name, string description) : base(name)
        {
            Description = description;
        }
        public Episode()
        {

        }
    }
}
