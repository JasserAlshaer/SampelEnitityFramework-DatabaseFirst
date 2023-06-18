using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampelEnitityFramework_DatabaseFirst.DTO;
using SampelEnitityFramework_DatabaseFirst.Models;

namespace SampelEnitityFramework_DatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private readonly StudendTableContext _context;
        public IndexController(StudendTableContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllCourses()
        {
            return Ok(_context.Courses);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetCourseById([FromRoute] int id)
        {
            return Ok(_context.Courses.Find(id));
        }
        [HttpPost]
        [Route("[action]")]
        public IActionResult AddId(CreateCourseDTO course)
        {
            Course course1 = new Course();
            course1.Title = course.Title;
            course1.Description = course.Description;
            course1.Price = course.Price;
            _context.Add(course1);
            _context.SaveChanges();


            return Ok(course1.Id);






        }

        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateCourse(UpdateCourseDTO course)
        {
            var selectId = _context.Courses.Find(course.Id);
            if (selectId != null)
            {
                selectId.Title = course.Title;
                selectId.Description = course.Description;
                selectId.Price = course.Price;
                _context.Update(selectId);
                _context.SaveChanges();


                return Ok(selectId.Id);

            }

            return new ObjectResult(" :) ")
            {
                StatusCode = 400
            };




        }
        [HttpDelete]
        [Route("delete/{idcours}")]
        public IActionResult Delete([FromRoute] int idcours)
        {

            var selectId = _context.Courses.Find(idcours);
            if (selectId != null)
            {
                _context.Remove(selectId);
                _context.SaveChanges();
                return new ObjectResult("Done") { StatusCode = 200 };
            }
            else 
            {
                return new ObjectResult("Failed") { StatusCode = 400};
            }
        }
    }
}