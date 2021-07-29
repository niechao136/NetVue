using IBAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetVue.Controllers.API
{
    [Route("api")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IBAL_User _ibalUser;

        public UserController(IBAL_User ibalUser)
        {
            _ibalUser = ibalUser;
        }


        [Route("user/register")]
        [HttpPost]
        public JObject RegisterUser([FromBody] JObject data)
        {
            JObject info = new JObject
            {
                new JProperty("nickname", data?["nickname"]?.ToString()),
                new JProperty("sex", data?["sex"]?.ToString())
            };
            User user = new User
            {
                email = data?["email"]?.ToString(),
                password = Common.MD5String(data?["password"]?.ToString()), 
                info = info.ToString()
            };
            return JsonConvert.DeserializeObject<JObject>(_ibalUser.RegisterUser(user));
        }

        [Route("password/reset")]
        [HttpPost]
        public JObject ResetPassword([FromBody] JObject data)
        {
            return JsonConvert.DeserializeObject<JObject>(_ibalUser.ResetPassword(data?["email"]?.ToString()));
        }
    }
}