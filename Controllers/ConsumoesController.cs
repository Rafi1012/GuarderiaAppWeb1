using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuarderiaAppWeb.Data;
using GuarderiaAppWeb.Models;

namespace GuarderiaAppWeb.Controllers
{
    public class ConsumoesController : Controller
    {
        private readonly GuarderiaContext _context;

        public ConsumoesController(GuarderiaContext context)
        {
            _context = context;
        }

        // GET: Consumoes
        public async Task<IActionResult> Index()
        {
            var guarderiaContext = _context.Consumos.Include(c => c.Nino);
            return View(await guarderiaContext.ToListAsync());
        }

        // GET: Consumoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.Nino)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // GET: Consumoes/Create
        public IActionResult Create()
        {
            ViewData["Matricula"] = new SelectList(_context.Ninos, "Matricula", "Matricula");
            return View();
        }

        // POST: Consumoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsumo,Fecha,Matricula,IdMenu,Total")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matricula"] = new SelectList(_context.Ninos, "Matricula", "Matricula", consumo.Matricula);
            return View(consumo);
        }

        // GET: Consumoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            ViewData["Matricula"] = new SelectList(_context.Ninos, "Matricula", "Matricula", consumo.Matricula);
            return View(consumo);
        }

        // POST: Consumoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsumo,Fecha,Matricula,IdMenu,Total")] Consumo consumo)
        {
            if (id != consumo.IdConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoExists(consumo.IdConsumo))
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
            ViewData["Matricula"] = new SelectList(_context.Ninos, "Matricula", "Matricula", consumo.Matricula);
            return View(consumo);
        }

        // GET: Consumoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumo = await _context.Consumos
                .Include(c => c.Nino)
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (consumo == null)
            {
                return NotFound();
            }

            return View(consumo);
        }

        // POST: Consumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumos.Remove(consumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoExists(int id)
        {
            return _context.Consumos.Any(e => e.IdConsumo == id);
        }
    }
}
