using Proyecto_MVC_Falabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_Falabella.Controllers
{
    public class CuentaController : Controller
    {

Contexto_Datos Contexto_Datos1 = new Contexto_Datos();

        public ActionResult Login()
        {
            return View(new Asesor());
        }

        public ActionResult Iniciar_Sesion(Asesor Asesor)
        {

Asesor Asesor1 = Contexto_Datos1.Asesor.Where(x => x.Correo == Asesor.Correo && x.Contrasenia == Asesor.Contrasenia).FirstOrDefault();

if (Asesor1 != null)
{

Session["IdAsesor"] = Asesor1.id;

return RedirectToAction("Panel_Control", "Contenido");

		}

            return View("Login", new Asesor());
        }

    }
}