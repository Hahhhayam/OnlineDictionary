using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDictionary.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using OnlineDictionary.API.DTO;

namespace OnlineDictionary.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly OnlineDictionaryContext db = new OnlineDictionaryContext();
        
        [HttpPatch("login")]
        public void Login
            (
                [FromBody] AuthDTO dto
            ) 
        {
            var admin = db.Users.Single(x => x.Login == dto.Login && x.Password == dto.Password);
            admin.IsLogined = true;
            db.SaveChanges();
        }

        [HttpPatch("logout")]
        public void Logout
            ()
        {
            var admin = db.Users.Single(x => x.Id == 1);
            admin.IsLogined = false;
            db.SaveChanges();
        }

        [HttpGet]
        public ActionResult<bool> IsLogin
            () 
        {
            return db.Users.Single(x => x.Id == 1).IsLogined;
        }
        
    }
}
