using System.ComponentModel.DataAnnotations;

namespace Dharati.Models
{
    public class RegistrationModel
    {
        [Key]
        public int RegistrationId {  get; set; }

        [Required]
        public string UserName  { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
