using System.Linq;

namespace Orders.Services.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Get(int id);
        bool Put(int id,T model);
        bool Delete(int id);
        void Post(T model);
    }
}