using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace intro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private List<Student> _students;
        public StudentsController()
        {
            _students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Name="Elmar"
                },
                new Student()
                {
                    Id = 2,
                    Name="Ramzi"
                },
                new Student()
                {
                    Id = 1,
                    Name="Raghsana"
                },
                new Student()
                {
                    Id = 1,
                    Name="Hamid"
                }
            };
        }

        public IActionResult GetAll()
        {
            return Ok(_students);
        }
    }
}
