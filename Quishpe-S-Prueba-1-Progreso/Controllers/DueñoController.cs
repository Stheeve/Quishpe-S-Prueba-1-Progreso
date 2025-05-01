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
    public class DueñoController : Controller
    {
        private readonly Quishpe_S_Prueba_1_ProgresoContext _context;

        public DueñoController(Quishpe_S_Prueba_1_ProgresoContext context)
        {
            _context = context;
        }

        // GET: Dueño
        public async Task<IActionResult> Index()
        {
            return View(await _context.Dueño.ToListAsync());
        }

        // GET: Dueño/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueño
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueño == null)
            {
                return NotFound();
            }

            return View(dueño);
        }

        // GET: Dueño/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dueño/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Telefono,Email,NumMascotas,FechaNacimiento,IngresoMensual")] Dueño dueño)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dueño);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dueño);
        }

        // GET: Dueño/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueño.FindAsync(id);
            if (dueño == null)
            {
                return NotFound();
            }
            return View(dueño);
        }

        // POST: Dueño/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Telefono,Email,NumMascotas,FechaNacimiento,IngresoMensual")] Dueño dueño)
        {
            if (id != dueño.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dueño);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DueñoExists(dueño.Id))
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
            return View(dueño);
        }

        // GET: Dueño/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dueño = await _context.Dueño
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dueño == null)
            {
                return NotFound();
            }

            return View(dueño);
        }

        // POST: Dueño/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dueño = await _context.Dueño.FindAsync(id);
            if (dueño != null)
            {
                _context.Dueño.Remove(dueño);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DueñoExists(int id)
        {
            return _context.Dueño.Any(e => e.Id == id);
        }
    }
}
