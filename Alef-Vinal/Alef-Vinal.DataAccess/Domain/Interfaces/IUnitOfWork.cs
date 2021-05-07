using Alef_Vinal.DataAccess.Domain.Entities;

namespace Alef_Vinal.DataAccess.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ValueCode, int> ValueCode { get; }

        void Save();
    }
}
