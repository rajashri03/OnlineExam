using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentBL bl;
        public StudentController(IStudentBL bl)
        {
            this.bl = bl;
        }
        [HttpPost("StudentLogin")]
        public IActionResult Studentlogin(string username,string password)
        {
            try
            {
                var reg = this.bl.StudentLogin(username,password);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Student login Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "login Unsucessfull" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
