using DataAccess;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace BusinessLogic.Controllers
{
    public class CategoryController : EntityController<Category>
    {
        private CategoryRepository CategoryRepository;
        private FeedController FeedController = new FeedController();
        public CategoryController()
        {
            CategoryRepository = new CategoryRepository();
            FeedController = new FeedController();
        }

        override
        public void Create(string name)
        {
            Category category = new Category(name);
            CategoryRepository.Create(category);
        }

        override
        public List<Category> ReadListFromFile()
        {
            return CategoryRepository.Read();
        }

        override
        public void Update(string oldName, string newName)
        {
            List<Category> categoryToChange = CategoryRepository.ListOfCategories.Where(x => x.Name.Equals(oldName)).ToList();
            categoryToChange[0].Name = newName;
            CategoryRepository.Update();
            
        }

        override
        public void Delete(string category)
        {
            CategoryRepository.ListOfCategories = CategoryRepository.ListOfCategories.Where(x => x.Name != category).ToList();
            CategoryRepository.Update();
           // FeedController.DeleteFeedsWithCategory(category);
        }

        public List<Category> GetListOfCategories()
        {
            return CategoryRepository.ListOfCategories;
        }

        override
        public bool FileExists()
        {
            return CategoryRepository.CheckForFile();
        }
    }
}
