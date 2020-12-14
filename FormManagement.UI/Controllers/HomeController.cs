using FormManagement.DAL;
using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManagement.UI.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        UnitOfWork uofwork = new UnitOfWork(new FormManagementEntities());
        [HttpGet]
        [Route("")]
        public ActionResult anasayfa()
        {
            ViewBag.Forms = uofwork.FormRepository.GetAll();
            return View("Index", new Form());
        }

        [HttpGet]
        [Route("forms")]
        public ActionResult Index()
        {
            ViewBag.Forms = uofwork.FormRepository.GetAll();
            return View(new Form());
        }

        [HttpGet]
        [Route("forms/{id}")]
        public ActionResult Goruntule(int id)
        {
            var form = uofwork.FormRepository.GetById((int)id); ;
            if (form == null)
            {
                return HttpNotFound();
            }
            return View("Goruntule", form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("forms")]
        public ActionResult Ekle(Form form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string username = User.Identity.Name;
                    var user = uofwork.LoginRepository.GetUser(username);

                    form.createdAt = DateTime.Now;
                    form.createdBy = user.Id;
                    uofwork.FormRepository.Add(form);
                    uofwork.CompleteSave();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}