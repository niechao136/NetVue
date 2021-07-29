using System;

namespace Model
{
    public class User
    {
        public int user_id { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string info { set; get; }
        public DateTime create_at { set; get; }
        public DateTime update_at { set; get; }
    }
}