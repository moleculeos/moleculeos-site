using System.ComponentModel.DataAnnotations;

namespace MoleculeOSSite.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        
        public int RoleId { get; set; } = 1;
        public virtual Role Role { get; set; }
    }
}
