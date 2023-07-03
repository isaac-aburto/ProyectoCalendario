
using ProyectoCalendario.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            using (ModeloCalendarioEntities conexion = new ModeloCalendarioEntities())
            {

                var usuario = conexion.Usuarios.Where(w => w.nombre == "Isaac").FirstOrDefault();
                Session["IdUsuario"] = usuario.id_usuario;
                ViewData["nombreUsuario"] = usuario.nombre;
            }
            return View();
        }
        public string HorasAgendadas(string formattedDateInput)
        {
            string numero = "0";
            DateTime fecha;
            using (ModeloCalendarioEntities conexion = new ModeloCalendarioEntities())
            {
                if (DateTime.TryParseExact(formattedDateInput, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
                {
                    DateTime fechaDb = DateTime.ParseExact(fecha.ToString("yyyy-MM-dd HH:mm:ss.fff"), "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

                     numero = conexion.Reserva.Where(w => w.fecha == fechaDb).Count().ToString();

                    // Resto del código para trabajar con la lista de reservas
                }
            }
            return numero;
        }


        public string AgendarHora(string diaSeleccionado)
        {
    
            // Método ToString()
            string idUsuario = Session["IdUsuario"].ToString();
            int id_user = int.Parse(idUsuario);
            DateTime fecha;

            // Utilizando DateTime.ParseExact
            fecha = DateTime.ParseExact(diaSeleccionado, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            // Utilizando DateTime.TryParseExact
            if (DateTime.TryParseExact(diaSeleccionado, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha))
            {
                // La cadena se pudo convertir correctamente a DateTime
                Console.WriteLine("Fecha: " + fecha);
            }

            using (ModeloCalendarioEntities conexion = new ModeloCalendarioEntities())
            {
                Reserva reserva = new Reserva();
                reserva.fecha = fecha;
                reserva.fk_usuario = id_user;
                conexion.Reserva.Add(reserva);
                conexion.SaveChanges();
            }

            return "";
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
    }
}