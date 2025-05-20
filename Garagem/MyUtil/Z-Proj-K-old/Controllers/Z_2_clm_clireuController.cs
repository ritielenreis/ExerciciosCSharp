using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KRONOS.DAL;
using KRONOS.Models;
using Ngeral.Controllers;

namespace KRONOS.Controllers
{
    
    public class Z_2_clm_clireuController : Controller
    {
        
        private clContext db = new clContext();
        public estado e = new estado();

        // GET: Zclm_clireuSELECT
        public ActionResult Index(string str_cli_id_drop)
        {
            //se a session estiver vazia, o cliente por omissão será o 5:
            e.cliid_na_drop = (e.cliid_na_drop == null) ? "5" : e.cliid_na_drop;
            //se a string que vem da drop está vazia, ficará com o cliente que estiver XXXXXXXXXXXXXX:
            str_cli_id_drop = (str_cli_id_drop != null) ? str_cli_id_drop : e.cliid_na_drop;


            //com o código, ir buscar o nome do cliente:
            clm_clientes registo = db.Tclientes.Find(Convert.ToInt16(str_cli_id_drop));
            //adicionar uma linha à selectlist; irá no topo:
            SelectListItem linha = new SelectListItem() { Value = str_cli_id_drop, Text = registo.cliente };
            List<SelectListItem> lista_de_linhas = new List<SelectListItem>();
            lista_de_linhas.Add(linha);

            //adicionar todos os clientes da tabela à selectlist:         
            foreach (var item in db.Tclientes)
            {
                linha = new SelectListItem { Value = item.codcli, Text = item.cliente };
                lista_de_linhas.Add(linha);
            }

            //devolver a lista à drop (à View):
            ViewBag.lista_de_clientes = new SelectList(lista_de_linhas, "value", "text");
            //devolver as mensagens desse cliente:
            var T = db.Tclireu.Include(c => c.cli);
            T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop));
            return View(T.ToList());
        }

        // GET: Zclm_clireuSELECT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clireu clm_clireu = db.Tclireu.Find(id);
            if (clm_clireu == null)
            {
                return HttpNotFound();
            }
            return View(clm_clireu);
        }

        // GET: Zclm_clireuSELECT/Create
        public ActionResult Create()
        {
            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli");
            return View();
        }

        // POST: Zclm_clireuSELECT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,textodescricao,dataY,textopresentes,Importante,Reservado,historico,Autor,cliID")] clm_clireu clm_clireu)
        {
            if (ModelState.IsValid)
            {
                db.Tclireu.Add(clm_clireu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli", clm_clireu.cliID);
            return View(clm_clireu);
        }

        // GET: Zclm_clireuSELECT/Edit/5 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clireu clm_clireu = db.Tclireu.Find(id);
            if (clm_clireu == null)
            {
                return HttpNotFound();
            }
            //guardar na session o código de cliente da mensagem editada:
            e.cliid_na_drop = clm_clireu.cliID.ToString();

            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli", clm_clireu.cliID);
            return View(clm_clireu);
        }

        // POST: Zclm_clireuSELECT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,textodescricao,dataY,textopresentes,Importante,Reservado,historico,Autor,cliID")] clm_clireu clm_clireu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clm_clireu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli", clm_clireu.cliID);

            return View(clm_clireu);
        }

        // GET: Zclm_clireuSELECT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clm_clireu clm_clireu = db.Tclireu.Find(id);
            if (clm_clireu == null)
            {
                return HttpNotFound();
            }
            return View(clm_clireu);
        }

        // POST: Zclm_clireuSELECT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clm_clireu clm_clireu = db.Tclireu.Find(id);
            db.Tclireu.Remove(clm_clireu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
