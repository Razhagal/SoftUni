using System.ComponentModel.DataAnnotations;

namespace IRunes.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
