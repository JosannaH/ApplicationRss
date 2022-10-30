using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryRepository : IRepository<Category>
    {
        private SerializerForXml SerializerForXml;
        public List<Category> ListOfCategories { get; set; }    

        public CategoryRepository()
        {
            SerializerForXml = new SerializerForXml();
        }
        public void Create(Category category)
        {
            ListOfCategories.Add(category);
            SerializerForXml.SerializeCategory(ListOfCategories);
        }
        public List<Category> Read()
        {
            ListOfCategories = SerializerForXml.DeserializeCategory();
            return ListOfCategories;
        }
        public void Update()
        {
            SerializerForXml.SerializeCategory(ListOfCategories);
        }

        public void Delete(List<Category> listOfCategories)
        {
            ListOfCategories = listOfCategories;
            SerializerForXml.SerializeCategory(ListOfCategories);
        }

        public bool CheckForFile()
        {
            return File.Exists("Categories.xml");
        }
    }
}
