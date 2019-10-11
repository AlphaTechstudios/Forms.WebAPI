using Forms.DA;
using Forms.Models;
using Forms.Repositories.Commun;
using Forms.Repositories.Interfaces;

namespace Forms.Repositories
{
    public class UsersRepository : GenericRepository<UserModel>, IUsersRepository
    {
        public UsersRepository(FormsContext context) 
            : base(context)
        {
        }
    }
}
