using Forms.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forms.Managers.Commun
{
    public class BaseManager
    {
        private readonly IUnitOfWork unitOfWork;

        public BaseManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork => unitOfWork;
    }
}
