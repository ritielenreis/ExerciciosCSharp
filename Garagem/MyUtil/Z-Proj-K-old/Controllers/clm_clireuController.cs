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
using Ngeral.Controllers; //para usar a classe estado
namespace KRONOS.Controllers
{
    public class clm_clireuController : Controller
    {
        private clContext db = new clContext();
        public estado e = new estado();

        // GET: clm_clireu
        public ActionResult Index(string str_cli_id_drop, string stringfiltro,
            string radioopcaoI, string radioopcaoR, string radioopcaoH,
            string radioopcaoOrdenarPorData)
        {
            if (radioopcaoI == null) ViewBag.radiobuttonimportante = true; else ViewBag.radiobuttonimportante = false;
            if (radioopcaoR == null) ViewBag.radiobuttonreservada = true; else ViewBag.radiobuttonreservada = false;
            if (radioopcaoH == null) ViewBag.radiobuttonhistorico = true; else ViewBag.radiobuttonhistorico = false;

            e.historico = (radioopcaoH != null ? radioopcaoH : e.historico);
            e.importante = (radioopcaoI != null ? radioopcaoI : e.importante);
            e.reservada= (radioopcaoR != null ? radioopcaoR : e.reservada);

            //se estiver vazio, o registo a apresentar é o 5º cliente (por exemplo)
            Session["cliIDnadrop"] = (Session["cliIDnadrop"] == null) ? "5" : Session["cliIDnadrop"];
            str_cli_id_drop = (str_cli_id_drop != null) ? str_cli_id_drop : Session["cliIDnadrop"].ToString();
            ViewBag.str_cli_id_drop= str_cli_id_drop;
            //agora, a string que vem da drop tem o valor proveniente do clique ou do método edit; vamos buscar  registo à tabela de
            //clientes, para ser o primeiro da lista que vai ser devolvida à drop da View Index; os restantes, adicionámo-los todos, 
            //desta forma, o valor por omissão a drop é o que lá estava antes
            clm_clientes registo = db.Tclientes.Find(Convert.ToInt16(str_cli_id_drop));
            //A: para os clientes que alimentam a adrop
            var A = from s in db.Tclientes select s;
            ViewBag.contaclitotal = A.Count();
            if (stringfiltro != null) A = A.Where(s => s.cliente.ToString().Contains(stringfiltro));

            ViewBag.contaclinadrop = A.Count();
            SelectListItem selListItem = new SelectListItem() { Value = str_cli_id_drop, Text = registo.cliente };
            List<SelectListItem> newList = new List<SelectListItem>();
            newList.Add(selListItem);
            foreach (var item in A)
            {
                selListItem = new SelectListItem { Value = item.ID.ToString(), Text = item.cliente };
                newList.Add(selListItem);
            }
            //com a lista construída, enviar pelo ViewBag para a drop na View index:            
            ViewBag.cliID = new SelectList(newList, "Value", "Text");

            //agora, as linhas para a página, a partir da outra tabela:
            var T = db.Tclireu.Include(c => c.cli);
            ViewBag.contalinhastotal = T.Count(); //total de registos 

            T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop));
            ViewBag.contalinhasdocliente = T.Count();
            //a classe estado alberga as propriedades historico, importante e e reservada, q são strings
            //aqui testa-se esse estado e converte-se para bool, pq os campos no modelo são desse tipo;
            //APLICAR ENTÃO OS "FILTROS":
            if (e.importante == "T")
                T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop));//CUIDADO: Contains? 14 contem 4, certo?
            else
                T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop) && (s.Importante == ((e.importante == "S") ? true : false)));

            if (e.reservada == "T")
                ViewBag.lixo="LIXO";// T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop));
                else
                 T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop) && (s.Reservado == ((e.reservada == "S") ? true : false)));

            if (e.historico == "T")
                ViewBag.lixo = "LIXO"; // T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop));
            else
                T = T.Where(s => s.cliID.ToString().Equals(str_cli_id_drop) && (s.historico == ((e.historico == "S") ? true : false)));

            //ordenar  data:
            if (radioopcaoOrdenarPorData == "C") T = T.OrderBy(s => s.dataY);
            else T = T.OrderByDescending(s => s.dataY);
            ViewBag.contalinhasparcial = T.Count();
            ViewBag.cliIDnadrop = Session["cliIDnadrop"];//para ver na View
            return View(T.ToList());
        }

        // GET: clm_clireu/Details/5
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

        // GET: clm_clireu/Create
        public ActionResult Create(int ? id)
        {
            if (id == null) id = 7;//se null, cliente por omissão é este
            //com o id da linha, encontrar o cliente:
            clm_clientes registo = db.Tclientes.Find(id);

            //ViewBag.nomeclinadrop = registo.cliente;
            //clm_clireu clm_clireu = db.Tclireu.Find(id);
            Session["cliIDnadrop"] = registo.codcli;
            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli",registo.codcli);
            return View();
        }

        // POST: clm_clireu/Create
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

            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli");
            return View(clm_clireu);
        }

        // GET: clm_clireu/Edit/5
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
            Session["cliIDnadrop"] = clm_clireu.cliID;
            ViewBag.cliID = new SelectList(db.Tclientes, "ID", "codcli", clm_clireu.cliID);
            return View(clm_clireu);
        }

        // POST: clm_clireu/Edit/5
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

        // GET: clm_clireu/Delete/5
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

        // POST: clm_clireu/Delete/5
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
