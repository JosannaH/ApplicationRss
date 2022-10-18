using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private List<Entity> ListOfObjects = new List<Entity>();

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
