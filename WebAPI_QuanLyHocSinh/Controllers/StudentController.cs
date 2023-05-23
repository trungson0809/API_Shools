
using WebAPI_QuanLyHocSinh.Dto;
using WebAPI_QuanLyHocSinh.Interfaces;
using WebAPI_QuanLyHocSinh.Context;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WebAPI_QuanLyHocSinh.Repository;
using DinkToPdf.Contracts;
using System;
using DinkToPdf;
using WebAPI_QuanLyHocSinh.Helpers;

namespace WebAPI_QuanLyHocSinh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly db_schoolsContext _context;
        private IConverter _converter;

        public StudentController(IStudentRepository studentRepository, IMapper mapper, db_schoolsContext context, IConverter converter)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _context = context;
            _converter = converter;
        }

        [HttpGet("{classId}/generatepdf")]
        public IActionResult GenerateToPDF(int classId)
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
               // Out = @"D:\PDFCreator\Employee_Report.pdf"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = _studentRepository.GeneratePDF(classId),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "style.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            var file = _converter.Convert(pdf);
            //return File(file, "application/pdf");
            return File(file, "application/pdf", classId+"_studentsReport.pdf");
            //_converter.Convert(pdf);
            //return Ok("Successfully created PDF document.");
        }
    
        // Get all
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetAll()
        {
            var students = _mapper.Map<List<StudentDto>>(_studentRepository.GetAllStudents());
          
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(students);
        }
       
        // Get by studentId
        [HttpGet("{studentId}")]
        [ProducesResponseType(200)]
        public IActionResult GetByStudentId(int studentId)
        {
            var student = _mapper.Map<StudentDto>(_studentRepository.GetStudent(studentId));
            return Ok(student);
        }
        // Get by Name
        [HttpGet("{name}/nameStudents")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public IActionResult GetByName(string name)
        {
            var students = _mapper.Map<List<StudentDto>>(_studentRepository.GetStudentsByName(name));


            return Ok(students);
        }
        // Get by class
        [HttpGet("{classId}/classStudents")]
        public IActionResult GetByClassId(int classId)
        {
            var students = _studentRepository.GetAllStudentOfClass(classId);
            return Ok(students);
        }
        // Get by rank
        [HttpGet("{rankName}/rankStudents")]
        public IActionResult GetByRankName(string rankName)
        {
            var students = _studentRepository.GetAllStudentOfRank(rankName);
            return Ok(students);
        }
        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Create([FromBody] StudentDto createStudent)
        {
            if (createStudent == null) 
                return BadRequest(ModelState);
           
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var StudentMap = _mapper.Map<Student>(createStudent);
            if (!_studentRepository.CreateStudent(StudentMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Tạo thành công");
        }
        //Edit
        [HttpPut("{studentId}")]
        public IActionResult Edit(int studentId, [FromBody] StudentDto editStudent)
        {
            if (editStudent == null) 
                return BadRequest(ModelState);

            if (studentId != editStudent.StudentId) 
                return BadRequest(ModelState);

            if (!_studentRepository.StudentExists(studentId)) 
                return NotFound();         

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var StudentMap = _mapper.Map<Student>(editStudent);
            if (!_studentRepository.EditStudent(StudentMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Sửa thành công");
        }

        //Delete
        [HttpDelete("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int studentId)
        {
            if (!_studentRepository.StudentExists(studentId))
                return NotFound();

            var StudentToDelete = _studentRepository.GetStudent(studentId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_studentRepository.DeleteStudent(StudentToDelete))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);

            }
            return Ok("Đã xoá học sinh: "+ studentId + " - " + StudentToDelete.Name);
        }



    }
}
