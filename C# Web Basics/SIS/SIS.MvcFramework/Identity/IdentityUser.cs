namespace SIS.MvcFramework.Identity
{
    public class IdentityUser
    {
        public IdentityUser()
        {
            this.Roles = new List<string>();
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public List<string> Roles { get; set; }
    }
}
