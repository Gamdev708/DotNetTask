using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly string _employeeName = "admin";
        private readonly string _employeePassword = "admin";
        private readonly string _candidate = "candidate";
        private readonly string _candidatePassword = "candidate";



        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
        {
            if (request.Username == _employeeName && request.Password == _employeePassword)
            {
                HttpContext.Session.SetString("User", _employeeName);
                return Ok(new LoginResponse { Success = true, Message = "Employee login successful" });
            }
            else if (request.Username == _candidate && request.Password == _candidatePassword)
            {
                HttpContext.Session.SetString("User", _candidate);
                return Ok(new LoginResponse { Success = true, Message = "Candidate login successful" });
            }
            else
            {
                return Unauthorized(new LoginResponse { Success = false, Message = "Invalid credentials" });
            }
        }

        [HttpPost("logout")]
        public ActionResult<LogoutResponse> Logout()
        {
            HttpContext.Session.Remove("User");
            return Ok(new LogoutResponse { Success = true, Message = "Logout successful" });
        }

        [HttpGet("checksession")]
        public ActionResult<bool> CheckSession()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return false;
            }
            return true;
        }
        [HttpGet("userType")]
        public ActionResult<LoginResponse> GetUserType()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                if (user == "admin")
                {
                    return Ok(new LoginResponse { Success = true, Message = "Employee" });
                }
                if (user == "candidate")
                {
                    return Ok(new LoginResponse { Success = false, Message = "Candidate" });
                }
            }
            return Ok(new LoginResponse { Success = false, Message = "No user Type" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class LogoutResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
