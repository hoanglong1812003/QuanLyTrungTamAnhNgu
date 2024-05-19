using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTrungTamAnhNgu.Data;

namespace QuanLyTrungTamAnhNgu.Controllers
{
    public class CtLapdatsController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public CtLapdatsController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: CtLapdats
        public async Task<IActionResult> Index()
        {
            var quanLyTrungTamAnhNguContext = _context.CtLapdats.Include(c => c.MatbNavigation).Include(c => c.SophieuNavigation);
            return View(await quanLyTrungTamAnhNguContext.ToListAsync());
        }

        // GET: CtLapdats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctLapdat = await _context.CtLapdats
                .Include(c => c.MatbNavigation)
                .Include(c => c.SophieuNavigation)
                .FirstOrDefaultAsync(m => m.Matb == id);
            if (ctLapdat == null)
            {
                return NotFound();
            }

            return View(ctLapdat);
        }

        // GET: CtLapdats/Create
        public IActionResult Create()
        {
            ViewData["Matb"] = new SelectList(_context.Thietbis, "Matb", "Matb");
            ViewData["Sophieu"] = new SelectList(_context.Phieulapdats, "Sophieu", "Sophieu");
            return View();
        }

        // POST: CtLapdats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matb,Sophieu,Ngaylapdat,Ghichu")] CtLapdat ctLapdat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctLapdat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Matb"] = new SelectList(_context.Thietbis, "Matb", "Matb", ctLapdat.Matb);
            ViewData["Sophieu"] = new SelectList(_context.Phieulapdats, "Sophieu", "Sophieu", ctLapdat.Sophieu);
            return View(ctLapdat);
        }

        // GET: CtLapdats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctLapdat = await _context.CtLapdats.FindAsync(id);
            if (ctLapdat == null)
            {
                return NotFound();
            }
            ViewData["Matb"] = new SelectList(_context.Thietbis, "Matb", "Matb", ctLapdat.Matb);
            ViewData["Sophieu"] = new SelectList(_context.Phieulapdats, "Sophieu", "Sophieu", ctLapdat.Sophieu);
            return View(ctLapdat);
        }

        // POST: CtLapdats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matb,Sophieu,Ngaylapdat,Ghichu")] CtLapdat ctLapdat)
        {
            if (id != ctLapdat.Matb)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctLapdat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtLapdatExists(ctLapdat.Matb))
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
            ViewData["Matb"] = new SelectList(_context.Thietbis, "Matb", "Matb", ctLapdat.Matb);
            ViewData["Sophieu"] = new SelectList(_context.Phieulapdats, "Sophieu", "Sophieu", ctLapdat.Sophieu);
            return View(ctLapdat);
        }

        // GET: CtLapdats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctLapdat = await _context.CtLapdats
                .Include(c => c.MatbNavigation)
                .Include(c => c.SophieuNavigation)
                .FirstOrDefaultAsync(m => m.Matb == id);
            if (ctLapdat == null)
            {
                return NotFound();
            }

            return View(ctLapdat);
        }

        // POST: CtLapdats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctLapdat = await _context.CtLapdats.FindAsync(id);
            if (ctLapdat != null)
            {
                _context.CtLapdats.Remove(ctLapdat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtLapdatExists(int id)
        {
            return _context.CtLapdats.Any(e => e.Matb == id);
        }
    }
}
