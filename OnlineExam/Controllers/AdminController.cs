using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Interfaces;

namespace OnlineExam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdminBL bl;
        public AdminController(IAdminBL bl)
        {
            this.bl = bl;
        }
        [HttpPost("Registration")]
        public IActionResult Registration(UsersModel model)
        {
            try
            {
                var reg = this.bl.Registration(model);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Registration Sucessfull", Response = reg });
                }
                else
                {

                    return this.BadRequest(new { Success = false, message = "Registration Unsucessfull" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [HttpPost("AdminLogin")]
        public IActionResult adminLogin(string username,string password)
        {
            try
            {
                var reg = this.bl.AdminLogin(username,password);
                if (reg != null)
                {
                    return this.Ok(new { Success = true, message = "Admin login Sucessfull", Response = reg });
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
