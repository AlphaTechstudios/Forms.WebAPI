using Forms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forms.Managers.Interfaces
{
    public interface IUsersManager
    {
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetUsers();
        long InsertUser(UserModel userModel);
        UserModel Login(LoginModel loginModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(int id);
    }
}
