using Microsoft.AspNetCore.Mvc;
using RifatSirProjectAPI5.Models;
using RifatSirProjectAPI5.Repository;

namespace RifatSirProjectAPI5.Controllers
{
    public class AdminController : Controller
    {
        [HttpPost("surji/admin/signIn2")]
        public IActionResult AdminSignIn2([FromBody] AdminAuth adminAuth)
        {
            if (adminAuth.username == "~admin" && adminAuth.password == "iit123")
            {
                return Ok(true);
            }

            return Ok(false);
        }
    }
}
