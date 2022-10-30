using System.Collections.Generic;

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
