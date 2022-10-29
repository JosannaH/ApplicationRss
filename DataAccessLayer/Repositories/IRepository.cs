using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> 
    {
        void Create(T entity);
        List<T> Read();
        void Update();
        void Delete(List<T> listOfEntities);
    }
}
