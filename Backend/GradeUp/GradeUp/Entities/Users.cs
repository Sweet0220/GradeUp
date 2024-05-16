namespace GradeUp.Entities
{
    public class Users
    {
        public long id {  get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string role { get; set; }

        public Users()
        {
            
        }

        public Users(string username, string email, string password, string name, string sex, string role)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.name = name;
            this.sex = sex;
            this.role = role;
        }
    }
}
