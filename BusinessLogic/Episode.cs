using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Episode : Entity
    {
        public string Description { get; set; }

        public Episode(string description, string name): base(name)
        {
            Description = description;
        }
    }
}
