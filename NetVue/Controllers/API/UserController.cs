using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using IBAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [Authorize]
        public JObject ResetPassword([FromBody] JObject data)
        {
            return JsonConvert.DeserializeObject<JObject>(_ibalUser.ResetPassword(data?["email"]?.ToString()));
        }

        [Route("login")]
        [HttpPost]
        public JObject Login([FromBody] JObject data)
        {
            Claim[] claims = {
                new Claim(ClaimTypes.Name, data?["email"]?.ToString())
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nechaonechaonechao"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
                "nechao",
                "nechao",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
            JObject status = new JObject
            {
                new JProperty("status", 1),
                new JProperty("token", new JwtSecurityTokenHandler().WriteToken(token))
            };
            return status;
        }
    }
}