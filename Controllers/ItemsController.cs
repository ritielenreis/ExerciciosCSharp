using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PKX.Data;
using PKX.Models;

namespace PKX.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext dbp;

        public ItemsController(ApplicationDbContext context)
        {
            dbp = context;
        }

        // GET: Items
        public IActionResult Index(int idCliente)
        {
            ViewBag.LISTADECLIENTES = new SelectList(dbp.Clientes, "Id", "NomeCliente");


            ViewBag.ITENS = "";
            ViewBag.QTDITENS = 0;

            //verifica se é o primeiro acesso
            if (idCliente == 0) { idCliente = -1; }

            //executa o codigo se nao for o primeiro acesso
            if (idCliente != -1)
            {

                var itensLista = dbp.Itens.Where(i => i.ClienteId == idCliente).ToList();
                //a ViewBag.ITENS recebe os valores da pesquisa

                foreach (var itens in itensLista)
                {
                    var idTipo = itens.TipoId;

                    var nomeTipo = dbp.Tipos.Where(i => i.Id == idTipo);

                }

                if (itensLista.Count() > 0)
                {
                    ViewBag.ITENS = itensLista;


                    //conta a quantidade de itens
                    ViewBag.QTDITENS = itensLista.Count();
                }
            }
            return View();
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await dbp.Itens
                .Include(i => i.ClienteVirtual)
                .Include(i => i.TipoVirtual)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(dbp.Clientes, "Id", "NomeCliente");
            ViewData["TipoId"] = new SelectList(dbp.Tipos, "Id", "Designacao");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,TipoId,Item1,Item2,Texto")] Item item)
        {
            if (ModelState.IsValid)
            {
                dbp.Add(item);
                await dbp.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(dbp.Clientes, "Id", "NomeCliente", item.ClienteId);
            ViewData["TipoId"] = new SelectList(dbp.Tipos, "Id", "Designacao", item.TipoId);
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await dbp.Itens.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(dbp.Clientes, "Id", "NomeCliente", item.ClienteId);
            ViewData["TipoId"] = new SelectList(dbp.Tipos, "Id", "Designacao", item.TipoId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,TipoId,Item1,Item2,Texto")] Item item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbp.Update(item);
                    await dbp.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(dbp.Clientes, "Id", "NomeCliente", item.ClienteId);
            ViewData["TipoId"] = new SelectList(dbp.Tipos, "Id", "Designacao", item.TipoId);
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await dbp.Itens
                .Include(i => i.ClienteVirtual)
                .Include(i => i.TipoVirtual)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await dbp.Itens.FindAsync(id);
            if (item != null)
            {
                dbp.Itens.Remove(item);
            }

            await dbp.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return dbp.Itens.Any(e => e.Id == id);
        }
    }
}
