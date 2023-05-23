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
    public class ResultController : Controller
    {
        private readonly IResultRepository _resultRepository;
        private readonly IMapper _mapper;

        public ResultController(IResultRepository resultRepository, IMapper mapper)
        {
            _resultRepository = resultRepository;
            _mapper = mapper;
        }
        // List
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Result>))]
        public IActionResult GetAll()
        {
            var Results = _mapper.Map<List<ResultDto>>(_resultRepository.GetAllResults());
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Results);
        }

        // Get by id
        [HttpGet("{resultId}")]
        [ProducesResponseType(200)]
        public IActionResult GetById(int resultId)
        {
            var _result = _mapper.Map<ResultDto>(_resultRepository.GetResultById(resultId));
            return Ok(_result);
        }
        //Add full students
        [HttpPost("results")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdateAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var oldResults = _resultRepository.GetAllResults();
            _resultRepository.RemoveAllResults((List<Result>)oldResults);

            

            if (!_resultRepository.UpdateAllResults())
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Tạo thành công");
        }
      
      
        //Edit
        [HttpPut("{ResultId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Edit (int ResultId, [FromBody] ResultDto editResult)
        {
            if (editResult == null) 
                return BadRequest(ModelState);

            if (ResultId != editResult.ResultId) 
                return BadRequest(ModelState);

            if (!_resultRepository.ResultExists(ResultId)) 
                return NotFound();         

            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var ResultMap = _mapper.Map<Result>(editResult);
            if (!_resultRepository.EditResult(ResultMap))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);
            }
            return Ok("Sửa thành công");
        }
        

        //Delete
        [HttpDelete("{ResultId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete (int ResultId)
        {
            if (!_resultRepository.ResultExists(ResultId))
                return NotFound();

            var ResultToDelete = _resultRepository.GetResultById(ResultId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_resultRepository.DeleteResult(ResultToDelete))
            {
                ModelState.AddModelError("", "Kiểm tra lại thao tác");
                return StatusCode(500, ModelState);

            }
            return Ok("Đã xoá kết quả HocSinh: " + ResultToDelete.StudentId);
        }



    }
}
