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
    public class CtHocphisController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public CtHocphisController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: CtHocphis
        public async Task<IActionResult> Index()
        {
            var quanLyTrungTamAnhNguContext = _context.CtHocphis.Include(c => c.MakhNavigation).Include(c => c.MaphieuNavigation);
            return View(await quanLyTrungTamAnhNguContext.ToListAsync());
        }

        // GET: CtHocphis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHocphi = await _context.CtHocphis
                .Include(c => c.MakhNavigation)
                .Include(c => c.MaphieuNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (ctHocphi == null)
            {
                return NotFound();
            }

            return View(ctHocphi);
        }

        // GET: CtHocphis/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh");
            ViewData["Maphieu"] = new SelectList(_context.Phieuthuhocphis, "Maphieu", "Maphieu");
            return View();
        }

        // POST: CtHocphis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makh,Maphieu,Mota")] CtHocphi ctHocphi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctHocphi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctHocphi.Makh);
            ViewData["Maphieu"] = new SelectList(_context.Phieuthuhocphis, "Maphieu", "Maphieu", ctHocphi.Maphieu);
            return View(ctHocphi);
        }

        // GET: CtHocphis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHocphi = await _context.CtHocphis.FindAsync(id);
            if (ctHocphi == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctHocphi.Makh);
            ViewData["Maphieu"] = new SelectList(_context.Phieuthuhocphis, "Maphieu", "Maphieu", ctHocphi.Maphieu);
            return View(ctHocphi);
        }

        // POST: CtHocphis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Makh,Maphieu,Mota")] CtHocphi ctHocphi)
        {
            if (id != ctHocphi.Makh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctHocphi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtHocphiExists(ctHocphi.Makh))
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
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctHocphi.Makh);
            ViewData["Maphieu"] = new SelectList(_context.Phieuthuhocphis, "Maphieu", "Maphieu", ctHocphi.Maphieu);
            return View(ctHocphi);
        }

        // GET: CtHocphis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctHocphi = await _context.CtHocphis
                .Include(c => c.MakhNavigation)
                .Include(c => c.MaphieuNavigation)
                .FirstOrDefaultAsync(m => m.Makh == id);
            if (ctHocphi == null)
            {
                return NotFound();
            }

            return View(ctHocphi);
        }

        // POST: CtHocphis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctHocphi = await _context.CtHocphis.FindAsync(id);
            if (ctHocphi != null)
            {
                _context.CtHocphis.Remove(ctHocphi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtHocphiExists(int id)
        {
            return _context.CtHocphis.Any(e => e.Makh == id);
        }
    }
}
