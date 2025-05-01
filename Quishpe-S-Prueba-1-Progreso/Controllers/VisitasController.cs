using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Quishpe_S_Prueba_1_Progreso.Data;
using Quishpe_S_Prueba_1_Progreso.Models;

namespace Quishpe_S_Prueba_1_Progreso.Controllers
{
    public class VisitasController : Controller
    {
        private readonly Quishpe_S_Prueba_1_ProgresoContext _context;

        public VisitasController(Quishpe_S_Prueba_1_ProgresoContext context)
        {
            _context = context;
        }

        // GET: Visitas1
        public async Task<IActionResult> Index()
        {
            var quishpe_S_Prueba_1_ProgresoContext = _context.Visita.Include(v => v.Mascota);
            return View(await quishpe_S_Prueba_1_ProgresoContext.ToListAsync());
        }

        // GET: Visitas1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // GET: Visitas1/Create
        public IActionResult Create()
        {
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "Id", "Id");
            return View();
        }

        // POST: Visitas1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaVisita,Motivo,RequiereMedicacion,IdMascota")] Visita visita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visita);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "Id", "Id", visita.IdMascota);
            return View(visita);
        }

        // GET: Visitas1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita.FindAsync(id);
            if (visita == null)
            {
                return NotFound();
            }
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "Id", "Id", visita.IdMascota);
            return View(visita);
        }

        // POST: Visitas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaVisita,Motivo,RequiereMedicacion,IdMascota")] Visita visita)
        {
            if (id != visita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visita);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitaExists(visita.Id))
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
            ViewData["IdMascota"] = new SelectList(_context.Mascota, "Id", "Id", visita.IdMascota);
            return View(visita);
        }

        // GET: Visitas1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visita = await _context.Visita
                .Include(v => v.Mascota)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visita == null)
            {
                return NotFound();
            }

            return View(visita);
        }

        // POST: Visitas1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visita = await _context.Visita.FindAsync(id);
            if (visita != null)
            {
                _context.Visita.Remove(visita);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitaExists(int id)
        {
            return _context.Visita.Any(e => e.Id == id);
        }
    }
}
