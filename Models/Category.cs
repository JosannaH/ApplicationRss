using System;
using System.Xml.Serialization;

namespace Models
{

    [Serializable]
    [XmlInclude(typeof(Category))]
    public class Category : Entity
    {
        public Category(string name) : base(name)
        {

        }

        public Category()
        {

        }
    } 
}
