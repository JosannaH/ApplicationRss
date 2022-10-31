using DataAccess;
using System.Collections.Generic;
using System.Linq;
using Models;
using System;

namespace BusinessLogic.Controllers
{
    public class CategoryController : EntityController<Category>
    {
        private CategoryRepository CategoryRepository;
        private Validator Validator;
        private MessageCreator MessageCreator;
        public CategoryController()
        {
            CategoryRepository = new CategoryRepository();
            Validator = new Validator();
            MessageCreator = new MessageCreator();
        }

        override
        public bool Create(string name)
        {
            bool success = false;
            List<Category> listOfCategories = CategoryRepository.ListOfCategories;
            if (Validator.IsUniqueName(name, listOfCategories))
            {
                Category category = new Category(name);
                CategoryRepository.Create(category);
                success = true;
            }
            else
            {
                MessageCreator.ShowMessage(MessageCreator.NameExists());
            }
            return success;
        }

        override
        public List<Category> ReadListFromFile()
        {
            return CategoryRepository.Read();
        }

        override
        public bool Update(string oldName, string newName)
        {
            bool success = false;
            List<Category> listOfCategories = CategoryRepository.ListOfCategories;
            if(Validator.IsUniqueName(newName, listOfCategories))
            {
                List<Category> categoryToChange = listOfCategories.Where(x => x.Name.Equals(oldName)).ToList();
                try
                {
                    categoryToChange[0].Name = newName;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new IndexOutOfRangeException("Can not find chosen category.");
                }
                CategoryRepository.Update();
                success = true;
            }
            else
            {
                MessageCreator.ShowMessage(MessageCreator.NameExists());
            }
            return success;
        }

        override
        public void Delete(string category)
        {
            CategoryRepository.ListOfCategories = CategoryRepository.ListOfCategories.Where(x => x.Name != category).ToList();
            CategoryRepository.Update();
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
