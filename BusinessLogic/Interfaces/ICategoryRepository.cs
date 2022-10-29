using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    internal interface ICategoryRepository<Category> : IRepository<Category>
    {
        void Update(Category category);
        void Delete(Category category);
    }
}
