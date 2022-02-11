using MoleculeOSSite.Entities;

namespace MoleculeOSSite
{
    public class Seeder
    {
        private readonly MyDbContext _context;

        public Seeder(MyDbContext context)
        {
            _context = context;
        }


        public void SeedRole()
        {
            if(_context.Database.CanConnect())
            {
                if(!_context.Roles.Any())
                {
                    var roles = GetRoles();
                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }
    }
}
