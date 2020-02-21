using Forms.Managers.Commun;
using Forms.Managers.Interfaces;
using Forms.Models;
using Forms.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

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

        public void DeleteUser(int id)
        {
            usersRepository.Delete(id);
            UnitOfWork.Commit();
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

        public UserModel Login(LoginModel loginModel)
        {
            var user = usersRepository.Get(x => x.Email == loginModel.Email && x.Password == loginModel.Password).SingleOrDefault();

            if(user != null)
            {
                return user.WithoutPassword();
            }
            return null;
        }

        public void UpdateUser(UserModel userModel)
        {
            var user = usersRepository.GetByID(userModel.Id);
            userModel.Password = user.Password;
            usersRepository.Update(userModel);
            UnitOfWork.Commit();
        }
    }
}
