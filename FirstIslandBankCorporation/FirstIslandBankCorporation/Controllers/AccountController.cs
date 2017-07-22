using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using FirstIslandBankCorporation.Models;
using Facade;

namespace FirstIslandBankCorporation.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {

        }
        
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                Session.Clear();
                Session.Abandon();
            }
            catch (Exception)
            {
            }
            ViewBag.Title = "Log in";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            MiniStatementFacade _miniStatementFacade = new MiniStatementFacade();
            var user = _miniStatementFacade.FindUserByEmail(model.Email);

            if (user.Password == model.Password)
            {
                try
                {
                    Session["UID"] = user.UserId;
                    Session["Email"] = user.Email;
                }
                catch (Exception)
                {

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
            }
            return View(model);
        }
        
        // POST: /Account/LogOff
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}