using System.Collections.Generic;
using Model;

namespace IBAL
{
    public interface IBAL_User
    {
        string RegisterUser(User user);
        User GetUserInfo(string user_id);
        List<User> GetUserList();
        void UpdateUserInfo(User user);
        void ChangePassword(string user_id, string password);
        string ResetPassword(string email);
    }
}