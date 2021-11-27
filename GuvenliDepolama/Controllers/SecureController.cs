using GuvenliDepolama.Models;
using System.Web.Mvc;

namespace GuvenliDepolama.Controllers
{
    public class SecureController : Controller
    {

        public ActionResult SignIn()
        {
            return View();
        }
        
        [HttpPost]
        public string SignIn(User item)
        {
            return "";
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(User item)
        {
            return "";
        }

    }
}