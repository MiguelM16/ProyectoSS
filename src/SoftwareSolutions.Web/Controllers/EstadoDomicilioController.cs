using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoftwareSolutions.Core.Domain;
using SoftwareSolutions.Infrastructure.Data;

namespace SoftwareSolutions.Web.Controllers
{
    public class EstadoDomicilioController : Controller
    {
        private readonly SoftwareSolutionsDbContext _context;

        public EstadoDomicilioController(SoftwareSolutionsDbContext context)
        {
            _context = context;
        }

        // GET: EstadoDomicilio
        public async Task<IActionResult> Index()
        {
            var softwareSolutionsDbContext = _context.EstadoDomicilio.Include(e => e.Id);
            return View(await softwareSolutionsDbContext.ToListAsync());
        }

        // GET: EstadoDomicilio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDomicilio = await _context.EstadoDomicilio
                .Include(e => e.Id)
                .FirstOrDefaultAsync(m => m.IdEstadoDomicilio == id);
            if (estadoDomicilio == null)
            {
                return NotFound();
            }

            return View(estadoDomicilio);
        }

        // GET: EstadoDomicilio/Create
        public IActionResult Create()
        {
            ViewData["IdDomicilio"] = new SelectList(_context.Domicilios, "IdDomicilio", "IdDomicilio");
            return View();
        }

        // POST: EstadoDomicilio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoDomicilio,EstadoDomicilio1,IdDomicilio,IdUsuario,IdVenta")] EstadoDomicilio estadoDomicilio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoDomicilio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDomicilio"] = new SelectList(_context.Domicilios, "IdDomicilio", "IdDomicilio", estadoDomicilio.IdDomicilio);
            return View(estadoDomicilio);
        }

        // GET: EstadoDomicilio/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDomicilio = await _context.EstadoDomicilio.FindAsync(id);
            if (estadoDomicilio == null)
            {
                return NotFound();
            }
            ViewData["IdDomicilio"] = new SelectList(_context.Domicilios, "IdDomicilio", "IdDomicilio", estadoDomicilio.IdDomicilio);
            return View(estadoDomicilio);
        }

        // POST: EstadoDomicilio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoDomicilio,EstadoDomicilio1,IdDomicilio,IdUsuario,IdVenta")] EstadoDomicilio estadoDomicilio)
        {
            if (id != estadoDomicilio.IdEstadoDomicilio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoDomicilio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoDomicilioExists(estadoDomicilio.IdEstadoDomicilio))
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
            ViewData["IdDomicilio"] = new SelectList(_context.Domicilios, "IdDomicilio", "IdDomicilio", estadoDomicilio.IdDomicilio);
            return View(estadoDomicilio);
        }

        // GET: EstadoDomicilio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estadoDomicilio = await _context.EstadoDomicilio
                .Include(e => e.Id)
                .FirstOrDefaultAsync(m => m.IdEstadoDomicilio == id);
            if (estadoDomicilio == null)
            {
                return NotFound();
            }

            return View(estadoDomicilio);
        }

        // POST: EstadoDomicilio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estadoDomicilio = await _context.EstadoDomicilio.FindAsync(id);
            _context.EstadoDomicilio.Remove(estadoDomicilio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoDomicilioExists(int id)
        {
            return _context.EstadoDomicilio.Any(e => e.IdEstadoDomicilio == id);
        }
    }
}
