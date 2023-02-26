namespace web_api.DTOs
{
    public class UserLoginDTO
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
