
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProyectoCalendario.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //using (ModeloCalendarioEntities2 conexion = new ModeloCalendarioEntities2()) {
     
            //    //var nombre = conexion.Usuarios.Where(w => w.nombre == "Isaac")
            //    //    .Select(s => s.nombre)
            //    //    .FirstOrDefault();
            //    //ViewData["nombreUsuario"] = nombre;
            //}
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}