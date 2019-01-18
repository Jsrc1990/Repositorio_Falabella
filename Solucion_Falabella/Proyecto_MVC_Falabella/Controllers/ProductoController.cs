using Proyecto_MVC_Falabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_Falabella.Controllers
{
public class ProductoController : Controller
{
#region "NAVEGACION"

Contexto_Datos Contexto_Datos1 = new Contexto_Datos();

public ActionResult Listar()
{
return View(Contexto_Datos1.Producto.OrderByDescending(x => x.Consecutivo).ToList());
}

public ActionResult Detallar(string id)
{
return View(Contexto_Datos1.Producto.Where(x => x.id == id).FirstOrDefault());
}

public ActionResult Crear()
{
ViewBag.Tipo_ProductoId = new SelectList(Contexto_Datos1.Tipo_Producto, "Id", "Nombre");
ViewBag.CompaniaId = new SelectList(Contexto_Datos1.Compania, "Id", "Nombre");
return View(new Producto());
}

public ActionResult Editar(string id)
{

ViewBag.Tipo_ProductoId = new SelectList(Contexto_Datos1.Tipo_Producto, "Id", "Nombre");
ViewBag.CompaniaId = new SelectList(Contexto_Datos1.Compania, "Id", "Nombre");
return View(Contexto_Datos1.Producto.Where(x => x.id == id).FirstOrDefault());
}

public ActionResult Eliminar(string id)
{
return View(Contexto_Datos1.Producto.Where(x => x.id == id).FirstOrDefault());
}

#endregion

#region "CRUD"

public ActionResult Guardar(Producto Producto)
{

ViewBag.Tipo_ProductoId = new SelectList(Contexto_Datos1.Tipo_Producto, "Id", "Nombre");
ViewBag.CompaniaId = new SelectList(Contexto_Datos1.Compania, "Id", "Nombre");

if (ModelState.IsValid)
{

try
{

Producto.id = Guid.NewGuid().ToString();

Contexto_Datos1.Producto.Add(Producto);

Contexto_Datos1.SaveChanges();

}
catch (Exception ex)
{
Console.WriteLine(ex.Message);
}

}

return View("Listar", Contexto_Datos1.Producto.OrderByDescending(x => x.Consecutivo).ToList());

}

public ActionResult Modificar(Producto Producto)
{

		if (ModelState.IsValid)
		{

		try
		{

		Producto Producto_Existente = Contexto_Datos1.Producto.Where(x => x.id == Producto.id).FirstOrDefault();

Producto_Existente.Nombre = Producto.Nombre;
Producto_Existente.Imagen = Producto.Imagen;
Producto_Existente.Descripcion = Producto.Descripcion;
Producto_Existente.Tipo_ProductoId = Producto.Tipo_ProductoId;
Producto_Existente.CompaniaId = Producto.CompaniaId;

		Contexto_Datos1.SaveChanges();

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		}


ViewBag.Tipo_ProductoId = new SelectList(Contexto_Datos1.Tipo_Producto, "Id", "Nombre");
ViewBag.CompaniaId = new SelectList(Contexto_Datos1.Compania, "Id", "Nombre");

return View("Listar", Contexto_Datos1.Producto.OrderByDescending(x => x.Consecutivo).ToList());
}

		public ActionResult Suprimir(string id)
		{

		try
		{

		Contexto_Datos1.Producto.Remove(Contexto_Datos1.Producto.Where(x => x.id == id).FirstOrDefault());

		Contexto_Datos1.SaveChanges();

		return RedirectToAction("Listar");

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		return View("Listar", Contexto_Datos1.Producto.OrderByDescending(x => x.Consecutivo).ToList());
		}


#endregion
}
}