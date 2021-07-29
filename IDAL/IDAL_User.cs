using System.Collections.Generic;
using Model;

namespace IDAL
{
    public interface IDAL_User
    {
        string RegisterUser(User user);
        User GetUserInfo(string user_id);
        List<User> GetUserList();
        string UpdateUserInfo(User user);
        string ChangePassword(string user_id, string password);
        string ResetPassword(string email);
    }
}