using System.Collections.Generic;
using IBAL;
using IDAL;
using Model;

namespace BAL
{
    public class BAL_User : IBAL_User
    {
        private readonly IDAL_User _idalUser;

        public BAL_User(IDAL_User idalUser)
        {
            _idalUser = idalUser;
        }
        
        public string RegisterUser(User user)
        {
            return _idalUser.RegisterUser(user);
        }

        public User GetUserInfo(string user_id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetUserList()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateUserInfo(User user)
        {
            throw new System.NotImplementedException();
        }

        public void ChangePassword(string user_id, string password)
        {
            throw new System.NotImplementedException();
        }

        public string ResetPassword(string email)
        {
            return _idalUser.ResetPassword(email);
        }
    }
}