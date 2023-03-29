using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using CommonLayer.Models;

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
        [Authorize]
        [HttpPost("AddCourse")]
        public IActionResult AddCourse(string coursename)
        {
            try
            {

                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "userId").Value);
                var reg = this.bl.AddCourse(coursename,userid);
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
        [Authorize]
        [HttpPost("AddSubject")]
        public IActionResult AddSubject(subjectmodel model)
        {
            try
            {

                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "userId").Value);
                var reg = this.bl.AddSubject(model, userid);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = $"{model.subjectname} Added Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to add subject" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("SetExam")]
        public IActionResult SetExam(setExamModel model)
        {
            try
            {

                //long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "userId").Value);
                var reg = this.bl.Setexam(model);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = $"exam setup done", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to set exam" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpGet("AllCourse")]
        public IActionResult Courses()
        {
            try
            {
                var reg = this.bl.GetAllCourse();
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = $"all Courses", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to fetch" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpPost("AddQuestion")]
        public IActionResult AddQuestion(QuestionModel model)
        {
            try
            {

                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "userId").Value);
                var reg = this.bl.AddQuestions(model,userid);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = $"Questions added successfully", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to questions" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
