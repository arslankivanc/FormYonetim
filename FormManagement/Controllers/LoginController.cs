using FormManagement.DAL;
using FormManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormManagement.Controllers
{
    public class LoginController : Controller
    {
        UnitOfWork uofwork = new UnitOfWork(new FormManagementEntities());
        // GET: giris
        [HttpGet]
        [Route("giris")]
        public ActionResult Login()
        {
            return View(new User());
        }

        // GET: kayitol
        [HttpGet]
        [Route("kayitol")]
        public ActionResult Kaydol()
        {
            return View(new User());
        }

        //POST:kayitol
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("kayitol")]
        public ActionResult Kaydol(User u)
        {
            if (ModelState.IsValid)
            {
                //Kayıtlı kullanıcı sorgusu
                var hasUsername = uofwork.LoginRepository.GetUser(u.username);
                if (hasUsername != null)
                {
                    ViewBag.Mesaj = "Kayıtlı kullanıcı adı zaten mevcuttur.Lütfen başka bir ad deneyiniz.";
                    u.password = null;
                    return View(u);
                }
                //Kullanıcı mevcut değilse kayıt ekler.
                try
                {
                    u.role = "user";
                    uofwork.LoginRepository.Add(u);
                    uofwork.CompleteSave();
                    ViewBag.Mesaj = "Kayıt işleminiz gerçekleşmiştir.";
                    return View(new User());
                }
                catch (Exception)
                {
                    return View(u);
                }
            }
            else return View(u);
        }

        //POST:giris
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("giris")]
        public ActionResult Login(User u)
        {
            if (ModelState.IsValid)
            {
                var user = uofwork.LoginRepository.GetUserWithPassword(u.username, u.password);
                //Kullanıcı mevcut ise oturum açılır
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.username, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Geçersiz kullanıcı adı ya da şifre";
                    return View(new User() { username = u.username });
                }
            }
            else
            {
                u.password = null;
                return View(u);
            }
        }
        //Cıkış
        [Route("cikis")]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}