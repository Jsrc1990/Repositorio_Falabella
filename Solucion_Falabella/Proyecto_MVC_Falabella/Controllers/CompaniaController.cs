using Proyecto_MVC_Falabella.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_MVC_Falabella.Controllers
{
	public class CompaniaController:Controller
	{

		#region "NAVEGACION"

		Contexto_Datos Contexto_Datos1 = new Contexto_Datos();

		public ActionResult Listar()
		{
		return View(Contexto_Datos1.Compania.OrderByDescending(x => x.Consecutivo).ToList());
		}

		public ActionResult Detallar(string id)
		{
		return View(Contexto_Datos1.Compania.Where(x => x.id == id).FirstOrDefault());
		}

		public ActionResult Crear()
		{
		return View(new Compania());
		}

		public ActionResult Editar(string id)
		{
		return View(Contexto_Datos1.Compania.Where(x => x.id == id).FirstOrDefault());
		}

		public ActionResult Eliminar(string id)
		{
		return View(Contexto_Datos1.Compania.Where(x => x.id == id).FirstOrDefault());
		}

		#endregion

		#region "CRUD"

		public ActionResult Guardar(Compania Compania)
		{

		if (ModelState.IsValid)
		{

		try
		{

		Compania.id = Guid.NewGuid().ToString();

		Contexto_Datos1.Compania.Add(Compania);

		Contexto_Datos1.SaveChanges();

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		}

		return View("Listar", Contexto_Datos1.Compania.OrderByDescending(x => x.Consecutivo).ToList());
		}

		public ActionResult Modificar(Compania Compania)
		{

		if (ModelState.IsValid)
		{

		try
		{

		Compania Compania_Existente = Contexto_Datos1.Compania.Where(x => x.id == Compania.id).FirstOrDefault();

Compania_Existente.Nombre = Compania.Nombre;
Compania_Existente.Imagen = Compania.Imagen;
Compania_Existente.Descripcion = Compania.Descripcion;

		Contexto_Datos1.SaveChanges();

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		}


		return View("Listar", Contexto_Datos1.Compania.OrderByDescending(x => x.Consecutivo).ToList());
		}

		public ActionResult Suprimir(string id)
		{

		try
		{

		Contexto_Datos1.Compania.Remove(Contexto_Datos1.Compania.Where(x => x.id == id).FirstOrDefault());

		Contexto_Datos1.SaveChanges();

		return RedirectToAction("Listar");

		}
		catch (Exception ex)
		{
		Console.WriteLine(ex.Message);
		}

		return View("Listar", Contexto_Datos1.Compania.OrderByDescending(x => x.Consecutivo).ToList());
		}

		#endregion



	}
}