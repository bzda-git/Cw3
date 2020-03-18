using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cw3.Models;
using Cw3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cw3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IDbService _dbService;

        public StudentsController(IDbService service)
        {
            _dbService = service;
        }

        //2. QueryString
        [HttpGet]
        public IActionResult GetStudents([FromServices]IDbService service, [FromQuery]string orderBy)
        {
            if (orderBy == "lastname")
            {
                return Ok(_dbService.GetStudents().OrderBy(s => s.lastName));
            }

            return Ok(_dbService.GetStudents());
        }

        //[FromRoute], [FromBody], [FromQuery]
        //1. URL segment
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Not found student");
        }

        //3. Body - cialo zadan
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.indexNumber = $"s{new Random().Next(1, 20000)}";
            //...
            return Ok(student); //JSON
        }

        
       

        [HttpPut("{id}")]
        public IActionResult AddStudent(int id)
        {

            return Ok(" Aktualizacja dokonczona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok(" Usuwanie ukonczone");
        }

    }
}