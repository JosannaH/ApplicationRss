using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Category : Entity
    {

        public List<Entity> ListOfFeeds { get; set; }

        public List<Entity> ListOfCategories { get; set; }

        private int lastUsedId = 0;

        public Category(string name) : base(name)
        {
            base.Id = lastUsedId + 1;
            lastUsedId = base.Id;
        }

        private void addFeedToCategoryList(Feed feed, string categoryName)
        {
            foreach(Category category in ListOfCategories)
            {
                if (category.Name.Equals(categoryName)){
                    category.ListOfFeeds.Add(feed);
                }
            }
        }
    }

    
}
