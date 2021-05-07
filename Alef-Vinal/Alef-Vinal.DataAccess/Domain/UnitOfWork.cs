using System;
using Alef_Vinal.DataAccess.Domain.Entities;
using Alef_Vinal.DataAccess.Domain.Interfaces;
using Alef_Vinal.DataAccess.Domain.Repositories;

namespace Alef_Vinal.DataAccess.Domain
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region private members

        private readonly Alef_VinalContext context;
        private IRepository<ValueCode, int> codeRepository;
        private bool disposed = false;

        #endregion

        public UnitOfWork(Alef_VinalContext context)
        {
            this.context = context;
        }

        public IRepository<ValueCode, int> ValueCode
        {
            get
            {
                if (codeRepository == null)
                    codeRepository = new ValueCodeRepository(context);
                return codeRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
