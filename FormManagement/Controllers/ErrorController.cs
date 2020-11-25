using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManagement.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        [Route("notfound")]
        public ActionResult NotFound()
        {
            return View();
        }
    }
}