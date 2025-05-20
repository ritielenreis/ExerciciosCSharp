using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KRONOS.DAL;
using APPLisTel.Models;




namespace APPLisTel.Controllers
{
    public class clLoginsController : Controller
    {
        private clContext db = new clContext();

       
        public ActionResult Index(string utilizador, string senha)
        {
            bool encontrado=false;
            var T = from s in db.Tlogin select s; //não precisa ordenação

            foreach (var item in T)
            {
                if (item.utilizador == utilizador && item.senha == senha)
                {
                    encontrado = true;
                    Session["user"] = utilizador;
                    ViewBag.X = utilizador;
                    Session["AuthState"] = "Authenticated";
                }
            }
            if (encontrado)
                return RedirectToAction((string)Session["sessionmethod"], (string)Session["sessioncontroller"]);

            return View();
        }

        public ActionResult Logout()
        {
           // myfuncs x = new myfuncs() -  se não fosse static
           
            Session["AuthState"] = "NOTAuthenticated";
            Session["user"] = "";                        
            return RedirectToAction("Index", "Home");     
               
        }      
    }
}
