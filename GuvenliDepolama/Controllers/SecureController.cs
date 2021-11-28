using GuvenliDepolama.Manager;
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
            var isOK = false;
            var err = "";
            try
            {
                SqlMnager sql = new SqlMnager();
                err = sql.AddUser(item);
                isOK = err.Length == 0;
            }
            catch (System.Exception)
            {
                throw;
            }          

            return Json(new { isOk = isOK,Msj = err }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(User item)
        {
            var isOK = false;            
            try
            {
                SqlMnager sql = new SqlMnager();
                var user = sql.CheckUser(item.Mail, item.Password);
                if (user != null)
                    isOK = true;
            }
            catch (System.Exception)
            {

                throw;
            }

            return Json(new { isOk = isOK }, JsonRequestBehavior.AllowGet);
        }

    }
}