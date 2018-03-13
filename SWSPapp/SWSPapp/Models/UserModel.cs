using System.ComponentModel.DataAnnotations;

namespace SWSPapp.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Pole wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}