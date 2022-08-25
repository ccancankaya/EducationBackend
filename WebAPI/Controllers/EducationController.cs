using DataAccess.Abstract;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : ControllerBase
    {
        private IEducationService _education;

        public EducationController(IEducationService education)
        {
            _education = education;
        }

        [HttpGet("educations")]
        public IActionResult GetEducations()
        {
            try
            {
                var result = _education.GetAll();

                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("education")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _education.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("educationbyprogram")]
        public IActionResult GetByProgram(int programId)
        {
            try
            {
                var result = _education.FindByCondition(e => e.EducationProgramId == programId);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return NoContent();
            }
        }
        [HttpPost("add")]
        public IActionResult AddEducation(Education education)
        {
            try
            {
                _education.Create(education);
                return Ok("Added");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update")]
        public IActionResult UpdateEducation(Education education)
        {
            try
            {
                _education.Update(education);
                return Ok("Updated");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult DeleteEducation(Education education)
        {
            try
            {
                _education.Delete(education);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
