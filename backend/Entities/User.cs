namespace MoleculeOSSite.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; } = 1; // Each user gets "User" role by default
        public Role Role { get; set; }
    }
}
