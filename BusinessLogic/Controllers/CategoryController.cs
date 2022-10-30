﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Models;
using System.Xml.Serialization;

namespace BusinessLogic.Controllers
{
    //[Serializable]
    //[XmlInclude(typeof(CategoryController))]
    public class CategoryController
    {
        CategoryRepository CategoryRepository;
        FeedController FeedController = new FeedController();
        public CategoryController()
        {
            CategoryRepository = new CategoryRepository();
            FeedController = new FeedController();
        }

        public void CreateCategory(string name)
        {
            Category category = new Category(name);
            CategoryRepository.Create(category);
        }

        public List<Category> ReadListOfCategoriesFromFile()
        {
            return CategoryRepository.Read();
        }

        public void UpdateCategory(string oldName, string newName)
        {
            List<Category> categoryToChange = CategoryRepository.ListOfCategories.Where(x => x.Name.Equals(oldName)).ToList();
            categoryToChange[0].Name = newName;
            CategoryRepository.Update();
            
        }

        public void DeleteCategory(string category)
        {
            CategoryRepository.ListOfCategories = CategoryRepository.ListOfCategories.Where(x => x.Name != category).ToList();
            CategoryRepository.Update();
            FeedController.DeleteFeedsWithCategory(category);
        }

        public List<Category> GetListOfCategories()
        {
            return CategoryRepository.ListOfCategories;
        }

        public bool FileOfFeedsExists()
        {
            return CategoryRepository.CheckForFile();
        }
    }
}
