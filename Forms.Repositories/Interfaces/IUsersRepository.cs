using Forms.Models;
using Forms.Repositories.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forms.Repositories.Interfaces
{
    public interface IUsersRepository : IGenericRepository<UserModel>
    {
    }
}
