using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoleculeOSSite.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        
        public string PasswordHash { get; set; }
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; } = 1;
        public virtual Role Role { get; set; }
    }
}
