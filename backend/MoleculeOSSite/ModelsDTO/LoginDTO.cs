using System.ComponentModel.DataAnnotations;

namespace MoleculeOSSite.ModelsDTO
{
    public class LoginDTO
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
