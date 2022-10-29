using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Models
{

    [Serializable]
    [XmlInclude(typeof(Category))]
    public class Category : Entity
    {
        //public List<Category> ListOfCategories { get; set; }

        public Category(string name) : base(name)
        {

        }

        public Category()
        {

        }
    } 
}
