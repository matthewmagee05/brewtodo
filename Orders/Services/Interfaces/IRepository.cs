using System.Linq;

namespace Orders.Services.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Get(int id);
        T Put(T model);
        T Delete(int id);
        T Post(T model);
    }
}