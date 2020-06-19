using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class Pokemon1Controller : Controller
    {
        // GET: Pokemon1
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Imagen(HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
            {
                string ruta = Path.Combine(Server.MapPath("~/imagenes"), Path.GetFileName(file.FileName));
                file.SaveAs(ruta);
                //usuario.Imagen= "/imagenes/" + Path.GetFileName(file.FileName);
            }

            return View("Index");
        }
    }
}