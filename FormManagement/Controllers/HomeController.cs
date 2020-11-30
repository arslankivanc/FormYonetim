using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FormManagement.BL.RepositoryClass;
using FormManagement.DAL.EntityFramework;

namespace FormManagement.Controllers
{
    [Authorize(Roles = "user")]
    public class HomeController : Controller
    {
        private IFormRepository _formRepo;

        public HomeController()
        {
            _formRepo = new FormRepository(new FormManagementEntities());
        }
        public HomeController(IFormRepository formRepository)
        {
            _formRepo = formRepository;
        }
        [HttpGet]
        [Route("")]
        public ActionResult anasayfa()
        {
            ViewBag.Forms = _formRepo.GetAllForms();
            return View("Index",_formRepo.form());
        }

        [HttpGet]
        [Route("forms")]
        public ActionResult Index()
        {
            ViewBag.Forms = _formRepo.GetAllForms();
            return View(_formRepo.form());
        }

        [HttpGet]
        [Route("forms/{id}")]
        public ActionResult Goruntule(int id)
        {
            var form = _formRepo.GetFormById(id);
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
                    var user = _formRepo.GetUser(username);

                    form.createdAt = DateTime.Now;
                    form.createdBy = user.Id;
                    _formRepo.Add(form);
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