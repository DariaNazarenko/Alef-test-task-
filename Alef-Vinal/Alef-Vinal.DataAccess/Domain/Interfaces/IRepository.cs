using System.Linq;

namespace Alef_Vinal.DataAccess.Domain.Interfaces
{
    public interface IRepository<T, K>
        where T : class
    {
        IQueryable<T> GetAll();
        T Get(K id);
        T GetByCode(int code);
        void Create(T item);
        void Update(T item);
    }
}
