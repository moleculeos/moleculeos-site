using Microsoft.AspNetCore.Mvc;
using MoleculeOSSite.Entities;

namespace MoleculeOSSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PersonController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> GetPeople()
        {
            return _context.People.ToList();
        }

        [HttpPost("{name}")]
        public OkResult CreatePerson([FromRoute] string name)
        {
            _context.People.Add(new Person { Name = name });
            _context.SaveChanges();
            return Ok();
        }
    }
}
