using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSAD_M2.Models.ViewModels.Correspondence;

namespace WSAD_M2.Controllers
{
    public class CorrespondenceController : Controller
    {
        // GET: Correspondence
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ContactEmailViewModel contactMessage)
        {
            return null;
        }
    }
}