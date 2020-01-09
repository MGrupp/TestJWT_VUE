namespace WebApiJWT.Models
{
    public class BOUser
    {
        public BOUser()
        {
            Id = 0;
            Email = string.Empty;
            Password = string.Empty;
            Country = string.Empty;
        }

        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Country { get; set; }
    }
}