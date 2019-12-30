using Forms.Models;
using System.Collections.Generic;
using System.Linq;

namespace Forms.Managers.Commun
{
    public static class UserModelExtensions
    {
        public static IEnumerable<UserModel> WithoutPassword(this IEnumerable<UserModel> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static UserModel WithoutPassword(this UserModel userModel)
        {
            userModel.Password = null;
            return userModel;
        }

    }
}
