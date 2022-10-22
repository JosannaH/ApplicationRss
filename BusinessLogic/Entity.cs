using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLogic
{

    [Serializable]
    [XmlInclude(typeof(Entity))]
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


        // list objects in combobox

        // list objects in listview

    }
}
