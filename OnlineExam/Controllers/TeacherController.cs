using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace OnlineExam.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        ITeacherBL bl;
        public TeacherController(ITeacherBL bl)
        {
            this.bl = bl;
        }
        [HttpPost("TeacherLogin")]
        public IActionResult Teacherlogin(string username, string password)
        {
            try
            {
                var reg = this.bl.TeacherLogin(username, password);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Teacher login Sucessfull", Response = reg });
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
        [HttpPost("AddCourse")]
        public IActionResult AddCourse(string coursename)
        {
            try
            {
                var reg = this.bl.AddCourse(coursename);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Course Added Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to add course" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
