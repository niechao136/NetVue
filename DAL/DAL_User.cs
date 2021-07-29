using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using IDAL;
using Model;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DAL
{
    public class DAL_User : IDAL_User
    {
        public string RegisterUser(User user)
        {
            JObject status = new JObject();
            using NpgsqlConnection connection = PostgreSQLCommon.OpenConnection();
            const string query = @"SELECT email FROM public.user WHERE email = @email";
            List<string> emails = connection.Query<string>(query, new {user.email}).ToList();
            if (emails.Count == 0)
            {
                const string sql = @"INSERT INTO public.user(email, password, info) VALUES (@email, @password, @info)";
                connection.Execute(sql, user);
                status.Add(new JProperty("status", 1));
                return status.ToString();
            }
            status.Add(new JProperty("status", 0));
            status.Add(new JProperty("msg", "email is existed"));
            return status.ToString();
        }

        public User GetUserInfo(string user_id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }

        public string UpdateUserInfo(User user)
        {
            throw new NotImplementedException();
        }

        public string ChangePassword(string user_id, string password)
        {
            throw new NotImplementedException();
        }

        public string ResetPassword(string email)
        {
            JObject status = new JObject();
            using NpgsqlConnection connection = PostgreSQLCommon.OpenConnection();
            const string query = @"SELECT email FROM public.user WHERE email = @email";
            List<string> emails = connection.Query<string>(query, new {email}).ToList();
            if (emails.Count == 0)
            {
                status.Add(new JProperty("status", 0));
                status.Add(new JProperty("msg", "email is not existed"));
                return status.ToString();
            }

            User user = new User
            {
                password = Common.MD5String("abc123"),
                email = email,
                update_at = DateTime.Now
            };
            const string sql = @"UPDATE public.user SET password = @password, update_at = @update_at WHERE email = @email";
            connection.Execute(sql, user);
            status.Add(new JProperty("status", 1));
            return status.ToString();
        }
    }
}