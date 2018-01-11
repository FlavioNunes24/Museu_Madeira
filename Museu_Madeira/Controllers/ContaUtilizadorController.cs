using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Museu_Madeira.Models;


namespace Museu_Madeira.Controllers
{
	public class ContaUtilizadorController : Controller
	{
		// GET: ContaUtilizador
		public ActionResult Index()
		{
			using (BdContext bd = new BdContext())
			{
				return View(bd.ContaUtilizador.ToList());
			}
		}

		public ActionResult Registo()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Registo(Utilizador utilizador)
		{

			if (ModelState.IsValid)
			{
				using (BdContext bd = new BdContext())
				{
					bd.ContaUtilizador.Add(utilizador);
					bd.SaveChanges();
					
				}
				ModelState.Clear();
				return RedirectToAction("Login");

				


			}
			return View();
		}


		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(Utilizador user)
		{
			using (BdContext bd = new BdContext())
			{
				var usr = bd.ContaUtilizador.Single(u => u.Username == user.Username && u.Password == user.Password);
				if (usr != null)
				{
					Session["UtilizadorId"] = user.UtilizadorId.ToString();
					Session["Username"] = user.Username.ToString();

					return RedirectToAction("Index","Home");
				}
				else
				{
					ModelState.AddModelError("","Username ou a password estão mal");
				}

			}
			return View();
		}

		public ActionResult LoggedIn()
		{
			if (Session["UtilizadorId"] != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Login");
			}
		}

	}
}