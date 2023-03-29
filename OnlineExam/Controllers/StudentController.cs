using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using RepositoryLayer.AppContext;

namespace OnlineExam.Controllers
{
    [Route("api/")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentBL bl;
        Context context;
        public StudentController(IStudentBL bl, Context context)
        {
            this.bl = bl;
            this.context = context;
        }
        [HttpPost("StudentRegistration")]
        public IActionResult Registration(Studentmodel model)
        {
            try
            {
                var reg = this.bl.StudentRegistation(model);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Student added Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "unable to add student" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
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
        [Authorize]
        [HttpGet("CoursebyId")]
        public IActionResult GetCoursebyId()
        {               
                try
                {
                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "studentid").Value);
                var query = (from student in context.StudentInfo
                                 join course in context.courses on student.courseid equals course.Courseid into alldata
                                 from studentcourse in alldata.DefaultIfEmpty()
                                     where student.studentid == userid
                             select new { student,studentcourse }).ToList();
                    if (query != null)
                    {
                        return this.Ok(new { Success = true, message = "student course", Response = query });
                    }
                    else
                    {
                        return this.Ok(new { Success = false, message = "Unable to fetch" });
                    }
                }
                catch (System.Exception)
                {

                    throw;
                }
            
        }
        // [Authorize]
        [HttpGet("GetSubject")]
        public IActionResult GetNote()
        {
            try
            {
                long userid = Convert.ToInt32(User.Claims.First(e => e.Type == "studentid").Value);
                var query = (from student in context.StudentInfo
                             join course in context.courses on student.courseid equals course.Courseid
                             join subjects in context.Subjects on course.Courseid equals subjects.Courseid into alldata
                             from studentcourse in alldata.DefaultIfEmpty()
                             where student.studentid == userid
                             select new { student, studentcourse }).ToList();
                if (query != null)
                {
                    return this.Ok(new { Success = true, message = "Course and subject data", Response = query });
                }
                else
                {
                    return this.Ok(new { Success = false, message = "Unable to fetch" });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
