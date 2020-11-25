using FormManagement.Models;
using FormManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FormManagement.Controllers
{
    [Authorize(Roles ="user")]
    public class HomeController : Controller
    {
        FormManagementEntities db = new FormManagementEntities();

        [HttpGet]
        [Route("")]
        public ActionResult anasayfa()
        {
            FormListesiViewModel formModel = new FormListesiViewModel()
            {
                form = new Form(),
                forms = db.Forms.Include(x => x.User).OrderByDescending(x => x.formName).ToList()
            };
            return View("Index",formModel);
        }

        [HttpGet]
        [Route("forms")]
        public ActionResult Index()
        {
            FormListesiViewModel formModel = new FormListesiViewModel() {
                form = new Form(),
                forms = db.Forms.Include(x=>x.User).OrderByDescending(x => x.formName).ToList()   
            };
            return View(formModel);
        }
        
        [HttpGet]
        [Route("forms/{id}")]
        public ActionResult Goruntule(int id)
        {
            var form = db.Forms.Find(id);
            if (form==null)
            {
                return HttpNotFound();
            }
            return View("Goruntule",form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("forms")]
        public ActionResult Ekle(FormListesiViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = db.Users.FirstOrDefault(x => x.username == User.Identity.Name);
                    formViewModel.form.createdAt = DateTime.Now;
                    formViewModel.form.createdBy = user.Id;
                    db.Forms.Add(formViewModel.form);
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else {
                return RedirectToAction("Index", "Home");
            }
        } 
    }
}