using System;
using System.Collections.Generic;
using System.Text;

namespace Forms.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
