using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dal.Interface;
using Dal.Services;
using GestContact.Models;
using GestContact.Tools;


namespace GestContact.Controllers
{
    public class UserController : Controller
    {
        private IUserService _service;

        public UserController()
        {
            _service = new UserService();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            try
            {
                User connectedUser = _service.Login(form.Email, form.Password).ToWEB();
                SessionManager.user = connectedUser;

                return RedirectToAction("List", "Contact");
            }
            catch(Exception e)
            {
                ViewBag.erreur = "Email ou mot de passe invalide";
                return View(form);
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterForm form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }

            _service.Insert(form.Email, form.Password, form.ScreenName);
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            SessionManager.Disconnect();
            return RedirectToAction("Index", "Home");
        }
    }
}