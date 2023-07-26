using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        // Get: https://localhost:7073/swagger/index.html

        [HttpGet]
       public IActionResult GetAllStudents()
        {
            string[] students = { "Vasu", "Pratik", "Rohan" };
            return Ok(students);
        }
    }
}

