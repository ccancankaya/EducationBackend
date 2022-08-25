using DataAccess.Abstract;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationProgramController : ControllerBase
    {
        private IEducationProgramService _educationProgram;

        public EducationProgramController(IEducationProgramService educationProgram)
        {
            _educationProgram = educationProgram;
        }

        [HttpGet("programs")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _educationProgram.GetWithEducations();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("program")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _educationProgram.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult AddEducationProgram(EducationProgram educationProgram)
        {
            try
            {
                _educationProgram.Create(educationProgram);
                return Ok("Added");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update")]
        public IActionResult UpdateEducationProgram(EducationProgram educationProgram)
        {
            try
            {
                _educationProgram.Update(educationProgram);
                return Ok("Updated");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteEducationProgram(EducationProgram educationProgram)
        {
            try
            {
                _educationProgram.Delete(educationProgram);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
