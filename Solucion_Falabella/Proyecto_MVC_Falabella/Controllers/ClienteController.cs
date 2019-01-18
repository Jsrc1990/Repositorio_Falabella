using Proyecto_MVC_Falabella.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_Falabella.Controllers
{
    public class ClienteController : Controller
    {

#region "NAVEGACION"

Contexto_Datos Contexto_Datos1 = new Contexto_Datos();

public ActionResult Listar()
{
return View(Contexto_Datos1.Cliente.OrderByDescending(x => x.Consecutivo).ToList());
}

public ActionResult Detallar(string id)
{
return View(Contexto_Datos1.Cliente.Where(x => x.id == id).FirstOrDefault());
}

public ActionResult Crear()
{
ViewBag.Tipo_DocumentoId = new SelectList(Contexto_Datos1.Tipo_Documento, "Id", "Nombre");
return View(new Cliente());
}

public ActionResult Editar(string id)
{
ViewBag.Tipo_DocumentoId = new SelectList(Contexto_Datos1.Tipo_Documento, "Id", "Nombre");
return View(Contexto_Datos1.Cliente.Where(x => x.id == id).FirstOrDefault());
}

public ActionResult Eliminar(string id)
{
return View(Contexto_Datos1.Cliente.Where(x => x.id == id).FirstOrDefault());
}

#endregion

#region "CRUD"

public ActionResult Guardar(Cliente Cliente)
{

if (ModelState.IsValid)
{

try
{

Contexto_Datos1.Cliente.Add(Cliente);

Contexto_Datos1.SaveChanges();

}
catch (Exception ex)
{
Console.WriteLine(ex.Message);
}

}

return View("Listar", Contexto_Datos1.Cliente.OrderByDescending(x => x.Consecutivo).ToList());

}

public ActionResult Modificar()
{

ViewBag.Tipo_DocumentoId = new SelectList(Contexto_Datos1.Tipo_Documento, "Id", "Nombre");

return View();
}

		public ActionResult Suprimir(string id)
		{

		try
		{

		Contexto_Datos1.Cliente.Remove(Contexto_Datos1.Cliente.Where(x => x.id == id).FirstOrDefault());

		Contexto_Datos1.SaveChanges();

		return RedirectToAction("Listar");

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		return View("Listar", Contexto_Datos1.Cliente.OrderByDescending(x => x.Consecutivo).ToList());
		}


#endregion



    }
}