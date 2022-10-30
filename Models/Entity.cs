using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{

    //[Serializable]
    //[XmlInclude(typeof(Entity))]
    public abstract class Entity
    {
        public string Name { get; set; }

        public Entity(string name)
        {
            Name = name;
        }
        public Entity()
        {

        }
    }
}
