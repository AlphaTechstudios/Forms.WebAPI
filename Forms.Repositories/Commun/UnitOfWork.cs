using Forms.DA;
using Forms.Repositories.Interfaces;
using System;

namespace Forms.Repositories.Commun
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        private FormsContext dbContext;

        private bool disposed = false;

        public UnitOfWork(FormsContext context)
        {
            dbContext = context;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposed)
        {
            if(!disposed)
            {
                if (!isDisposed)
                {
                    dbContext.Dispose();
                }
            }

            disposed = true;
        }
    }
}
