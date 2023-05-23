using WebAPI_QuanLyHocSinh.Dto;
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using WebAPI_QuanLyHocSinh.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebWebAPI_QuanLyHocSinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }
        // List
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Class>))]
        public IActionResult GetAll()
        {
            var classes = _mapper.Map<List<ClassDto>>(_classRepository.GetAllClasses());           
            return Ok(classes);
        }
        // Get by classId
        [HttpGet("{classId}")]
        [ProducesResponseType(200)]
        public IActionResult GetByClassId(int classId)
        {
            var _class = _mapper.Map<ClassDto>(_classRepository.GetClassById(classId));
            return Ok(_class);
        }
        // Get by class
        [HttpGet("{classId}/students")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetStudentByClassId(int classId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var students = _mapper.Map<List<StudentDto>>(_classRepository.GetStudentsByClassId(classId));
            return Ok(students);
        }
        //Create
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] ClassDto createClass)
        {
            if (createClass == null) return BadRequest(ModelState);

            var classes = _classRepository.GetAllClasses()
                .Where(c=>c.Name.Trim().ToUpper() == createClass.Name.Trim().ToLower())
                .FirstOrDefault();
            if(classes != null)
            {
                ModelState.AddModelError("", "Tên lớp đã tồn tại");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var classMap = _mapper.Map<Class>(createClass);
            if (!_classRepository.CreateClass(classMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Tạo thành công");
        }
        //Edit
        [HttpPut("{classId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Edit (int classId, [FromBody] ClassDto editClass)
        {
            if (editClass == null) 
                return BadRequest(ModelState);

            if (classId != editClass.ClassId) 
                return BadRequest(ModelState);

            if (!_classRepository.ClassExists(classId)) 
                return NotFound();         

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var classMap = _mapper.Map<Class>(editClass);
            if (!_classRepository.EditClass(classMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Sửa thành công");
        }

        //Delete
        [HttpDelete("{classId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete (int classId)
        {
            if (!_classRepository.ClassExists(classId))
                return NotFound();

            var classToDelete = _classRepository.GetClassById(classId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_classRepository.DeleteClass(classToDelete))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);

            }
            return Ok("Đã xoá lớp: "+ classId + " - " +classToDelete.Name);
        }



    }
}
