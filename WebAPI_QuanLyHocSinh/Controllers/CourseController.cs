using WebAPI_QuanLyHocSinh.Dto;
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI_QuanLyHocSinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository CourseRepository, IMapper mapper)
        {
            _courseRepository = CourseRepository;
            _mapper = mapper;
        }
        // List
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetAll()
        {
            var courses = _mapper.Map<List<CourseDto>>(_courseRepository.GetAllCourses());         
            return Ok(courses);
        }
        // Get by id
        [HttpGet("{courseId}")]
        [ProducesResponseType(200)]
        public IActionResult GetById(int courseId)
        {
            var _course = _mapper.Map<CourseDto>(_courseRepository.GetCourseById(courseId));
            return Ok(_course);
        }
        //Create
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] CourseDto createCourse)
        {
            if (createCourse == null) return BadRequest(ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var Courses = _courseRepository.GetAllCourses()
                .Where(c => c.StudentId == createCourse.StudentId && c.SubjectId == createCourse.SubjectId)
                .FirstOrDefault();
            if (Courses != null)
            {
                ModelState.AddModelError("", "Học sinh đã tham gia");
                return StatusCode(422, ModelState);
            }


            var CourseMap = _mapper.Map<Course>(createCourse);
            if (!_courseRepository.CreateCourse(CourseMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Tạo thành công");
        }
        //Edit
        [HttpPut("{courseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Edit (int courseId, [FromBody] CourseDto editCourse)
        {
            if (editCourse == null) 
                return BadRequest(ModelState);

            if (courseId != editCourse.CourseId) 
                return BadRequest(ModelState);

            if (!_courseRepository.CourseExists(courseId)) 
                return NotFound();         

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var CourseMap = _mapper.Map<Course>(editCourse);
            if (!_courseRepository.EditCourse(CourseMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Sửa thành công");
        }

        //Delete
        [HttpDelete("{courseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete (int courseId)
        {
            if (!_courseRepository.CourseExists(courseId))
                return NotFound();

            var CourseToDelete = _courseRepository.GetCourseById(courseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_courseRepository.DeleteCourse(CourseToDelete))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);

            }
            return Ok("Đã xoá học sinh "+ CourseToDelete.StudentId + " ra khỏi môn học " + CourseToDelete.SubjectId);
        }



    }
}
