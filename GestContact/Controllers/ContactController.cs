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
    [AuthRequired]
    public class ContactController : Controller
    {
        private IContactService _service;

        public ContactController()
        {
            _service = new ContactService();
        }

        public ActionResult List()
        {
            return View(_service.GetContactByUserId(SessionManager.user.Id));
        }

        public ActionResult Ajout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ajout(RegisterContact form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            _service.Insert(form.ToDAL());
            return RedirectToAction("List");
        }
    }
}