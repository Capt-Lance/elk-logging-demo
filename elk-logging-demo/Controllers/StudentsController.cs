using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elk_logging_demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace elk_logging_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly ILogger<StudentsController> logger;
        public StudentsController(ILogger<StudentsController> logger)
        {
            this.logger = logger;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Get()
        {

            Student student = new Student("000005", "Jane", "Doe");
            List<Student> students = new List<Student>() { student };
            logger.LogInformation("{@student} returned", student);
            return Ok(students);
        }

        [HttpGet("{studentId:int}")]
        public IActionResult GetSpecificStudent(int studentId)
        {
            logger.LogError("Cannot find student of id '{@studentId}'", studentId);
            return NotFound();
        }
    }
}
