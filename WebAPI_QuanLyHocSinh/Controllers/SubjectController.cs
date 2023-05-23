using WebAPI_QuanLyHocSinh.Dto;
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI_QuanLyHocSinh.Repository;

namespace WebAPI_QuanLyHocSinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        // List
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        public IActionResult GetAllSubjects()
        {
            var subjects = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetAllSubjects());       
            return Ok(subjects);
        }
        // Get by by id
        [HttpGet("{subjectId}")]
        [ProducesResponseType(200)]
        public IActionResult GetBySubjectID(int subjectId)
        {
            var _subject = _mapper.Map<SubjectDto>(_subjectRepository.GetSubjectById(subjectId));
            return Ok(_subject);
        }
        //Create
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult CreateSubject([FromBody] SubjectDto createSubject)
        {
            if (createSubject == null) return BadRequest(ModelState);
            var subjects = _subjectRepository.GetAllSubjects()
                .Where(c=>c.Name.Trim().ToUpper() == createSubject.Name.Trim().ToLower())
                .FirstOrDefault();
            if(subjects != null)
            {
                ModelState.AddModelError("", "Tên môn học đã tồn tại");
                return StatusCode(422, ModelState);
            }

            var subjectMap = _mapper.Map<Subject>(createSubject);
            if (!_subjectRepository.CreateSubject(subjectMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Tạo thành công");
        }
        //Edit
        [HttpPut("{subjectId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult EditClass (int subjectId, [FromBody] SubjectDto editSubject)
        {
            if (editSubject == null) 
                return BadRequest(ModelState);

            if (subjectId != editSubject.SubjectId) 
                return BadRequest(ModelState);

            if (!_subjectRepository.SubjectExists(subjectId)) 
                return NotFound();         
            var subjectMap = _mapper.Map<Subject>(editSubject);
            if (!_subjectRepository.EditSubject(subjectMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Sửa thành công");
        }

        //Delete
        [HttpDelete("{subjectId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteClass (int subjectId)
        {
            if (!_subjectRepository.SubjectExists(subjectId))
                return NotFound();

            var subjectToDelete = _subjectRepository.GetSubjectById(subjectId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_subjectRepository.DeleteSubject(subjectToDelete))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);

            }
            return Ok("Đã xoá môn học: "+ subjectId + " - " + subjectToDelete.Name);
        }



    }
}
