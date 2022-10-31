using System.Collections.Generic;

namespace BusinessLogic.Controllers
{
    public abstract class EntityController<T>
    {
        public virtual bool Create(string name)
        {
            return false;
        }

        public virtual bool Create(string name, string url, string category)
        {
            return false;
        }

        public virtual List<T> ReadListFromFile()
        {
            return null;
        }

        public virtual bool Update(string chosenFeed, string newName, string newUrl, string newCategory)
        {
            return false;
        }

        public virtual bool Update(string oldName, string newName)
        {
            return false;
        }

        public virtual void Delete(string name)
        {

        }

        public virtual bool FileExists()
        {
            return false;
        }
    }
}
