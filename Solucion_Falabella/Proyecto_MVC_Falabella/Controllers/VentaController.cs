using Proyecto_MVC_Falabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_Falabella.Controllers
{
    public class VentaController : Controller
    {

Contexto_Datos Contexto_Datos1 = new Contexto_Datos();

		#region "NAVEGACION"

		public ActionResult Listar()
        {
            return View(Contexto_Datos1.Venta.OrderByDescending(x => x.Consecutivo).ToList());
        }

        public ActionResult Crear()
        {
ViewBag.AsesorId = Session["IdAsesor"]; //new SelectList(Contexto_Datos1.Asesor, "Id", "Nombre");
//ViewBag.AsesorId = new SelectList(Contexto_Datos1.Asesor, "Id", "Nombre");
ViewBag.ClienteId = new SelectList(Contexto_Datos1.Cliente, "Id", "Nombre");
            return View(new Venta());
        }

		#endregion

		#region "CRUD"

public ActionResult Guardar(Venta Venta)
{

if (ModelState.IsValid)
{

try
{

Venta.id = Guid.NewGuid().ToString();

Contexto_Datos1.Venta.Add(Venta);

Contexto_Datos1.SaveChanges();

}
catch (Exception ex)
{
Console.WriteLine(ex.Message);
}

}

ViewBag.AsesorId = Session["IdAsesor"]; //new SelectList(Contexto_Datos1.Asesor, "Id", "Nombre");
ViewBag.ClienteId = new SelectList(Contexto_Datos1.Cliente, "Id", "Nombre");

return View("Listar", Contexto_Datos1.Venta.OrderByDescending(x => x.Consecutivo).ToList());

}


		#endregion

	}
}