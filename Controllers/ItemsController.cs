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
        public async Task<IActionResult> Index(String? s, int? Id)
        {

            var applicationDbContext = dbp.Itens.Include(i => i.ClienteVirtual).Include(i => i.TipoVirtual);

            Cliente c = dbp.Clientes.FirstOrDefault(m => m.NomeCliente == s);

            if (c != null)
            {
                Id = c.Id;
            }
            else { Id = -1; }

            //ViewBag.ListaClientes = new SelectList(_context.Clientes.OrderBy(m => m.NomeCliente), "Id", "NomeCliente", Id);

            if (Id.HasValue)
            {
                ViewBag.ListaItens = dbp.Itens
                    .Where(m => m.ClienteId == Id)
                    .ToList();
            }
            else
            {
                ViewBag.ListaItens = new List<Item>();
            }





            return View(await applicationDbContext.ToListAsync());
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
