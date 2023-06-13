namespace Sacral
{
    public class LoginAuthenticationModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}