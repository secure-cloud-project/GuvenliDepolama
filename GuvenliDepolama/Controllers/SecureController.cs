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
        public JsonResult SignIn(User item)
        {
            return Json(new { isOk = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(User item)
        {
            return Json(new { isOk = true }, JsonRequestBehavior.AllowGet);
        }

    }
}