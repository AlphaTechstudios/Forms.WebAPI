using Forms.Managers.Commun;
using Forms.Managers.Interfaces;
using Forms.Models;
using Forms.Repositories.Interfaces;
using System.Collections.Generic;

namespace Forms.Managers
{
    public class UsersManager : BaseManager, IUsersManager
    {
        private readonly IUsersRepository usersRepository;

        public UsersManager(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.usersRepository = usersRepository;
        }
        public UserModel GetUserById(int id)
        {
            return usersRepository.GetByID(id);
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return usersRepository.Get();
        }

        public long InsertUser(UserModel userModel)
        {
            var modelId = usersRepository.Insert(userModel);
            this.UnitOfWork.Commit();
            return modelId;
        }
    }
}
