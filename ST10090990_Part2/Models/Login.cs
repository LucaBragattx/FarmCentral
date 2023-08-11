namespace ST10090990_Part2.Models
{
    public class Login
    {
        public string? Name { get; set; }
        public string? Password { get; set; }  
        
        public string? User { get; set; }   

        public Login()
        {

        }

        public Login ( string name, string password, string user)
        {
            Name = name;
            Password = password;
            User = user;
        }
    }
}
