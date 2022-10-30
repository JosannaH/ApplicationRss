using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public abstract class EntityController<T>
    {
        public virtual void Create(string name)
        {

        }

        public virtual void Create(string name, string url, string category)
        {

        }

        public virtual List<T> ReadListFromFile()
        {
            return null;
        }

        public virtual void Update(string chosenFeed, string newName, string newUrl, string newCategory)
        {

        }

        public virtual void Update(string oldName, string newName)
        {

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
