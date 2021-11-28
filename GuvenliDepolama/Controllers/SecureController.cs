using GuvenliDepolama.Manager;
using GuvenliDepolama.Models;
using System.Web.Mvc;
using System.Web.Security;

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
                {
                    isOK = true;
                    SetLogin(user);                    
                }
            }
            catch (System.Exception)
            {

                throw;
            }            

            return Json(new { isOk = isOK }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        public ActionResult LogOut()
        {
            SetLogOut();
            return RedirectToAction("/Login");
        }

        private void SetLogin(User user)
        {
            //FormsAuthentication.SetAuthCookie(user.Name + " " + user.SurName, true);
            Session["User"] = user;
        }

        private void SetLogOut()
        {
            //FormsAuthentication.SignOut();
            Session["User"] = "";
        }
    }
}