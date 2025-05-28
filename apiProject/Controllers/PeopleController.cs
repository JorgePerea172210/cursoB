using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("all")]
        public List<People> GetPeople() => Repository.People;

        [HttpGet("{id}")]
        public People Get(int id) => Repository.People.First(p => p.Id == id);

        [HttpGet("search/{word}")]
        public List<People> Get(string word) =>
            Repository.People.Where(p => p.Name.ToUpper().Contains(word.ToUpper())).ToList();
    }

    public class Repository
    {
        public static List<People> People = new List<People>
        {
            new People()
            {
                Id = 1, Name = "Jorge", Birthdate = new DateTime(2005, 3, 8)
            },
            new People()
            {
                Id = 2, Name = "Andrea", Birthdate=new DateTime(2005, 3, 23)
            },
            new People()
            {
                Id = 3, Name = "Sara", Birthdate = new DateTime(2004, 8, 16)
            }
        };
    }

    public class People
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime Birthdate { get; set; }


    }
}
