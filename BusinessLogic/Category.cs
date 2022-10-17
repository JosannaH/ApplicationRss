using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category
    {

        
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Feed> ListOfFeeds { get; set; }

        public List<Category> ListOfCategories { get; set; }
    }

    
}
