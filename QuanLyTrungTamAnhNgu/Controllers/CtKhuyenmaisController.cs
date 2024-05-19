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
    public class CtKhuyenmaisController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public CtKhuyenmaisController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: CtKhuyenmais
        public async Task<IActionResult> Index()
        {
            var quanLyTrungTamAnhNguContext = _context.CtKhuyenmais.Include(c => c.MakhNavigation).Include(c => c.MakmNavigation);
            return View(await quanLyTrungTamAnhNguContext.ToListAsync());
        }

        // GET: CtKhuyenmais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctKhuyenmai = await _context.CtKhuyenmais
                .Include(c => c.MakhNavigation)
                .Include(c => c.MakmNavigation)
                .FirstOrDefaultAsync(m => m.Makm == id);
            if (ctKhuyenmai == null)
            {
                return NotFound();
            }

            return View(ctKhuyenmai);
        }

        // GET: CtKhuyenmais/Create
        public IActionResult Create()
        {
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh");
            ViewData["Makm"] = new SelectList(_context.Khuyenmais, "Makm", "Makm");
            return View();
        }

        // POST: CtKhuyenmais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makm,Makh,Ngaybatdau,Ngayketthuc")] CtKhuyenmai ctKhuyenmai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctKhuyenmai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctKhuyenmai.Makh);
            ViewData["Makm"] = new SelectList(_context.Khuyenmais, "Makm", "Makm", ctKhuyenmai.Makm);
            return View(ctKhuyenmai);
        }

        // GET: CtKhuyenmais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctKhuyenmai = await _context.CtKhuyenmais.FindAsync(id);
            if (ctKhuyenmai == null)
            {
                return NotFound();
            }
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctKhuyenmai.Makh);
            ViewData["Makm"] = new SelectList(_context.Khuyenmais, "Makm", "Makm", ctKhuyenmai.Makm);
            return View(ctKhuyenmai);
        }

        // POST: CtKhuyenmais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Makm,Makh,Ngaybatdau,Ngayketthuc")] CtKhuyenmai ctKhuyenmai)
        {
            if (id != ctKhuyenmai.Makm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctKhuyenmai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtKhuyenmaiExists(ctKhuyenmai.Makm))
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
            ViewData["Makh"] = new SelectList(_context.Khoahocs, "Makh", "Makh", ctKhuyenmai.Makh);
            ViewData["Makm"] = new SelectList(_context.Khuyenmais, "Makm", "Makm", ctKhuyenmai.Makm);
            return View(ctKhuyenmai);
        }

        // GET: CtKhuyenmais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctKhuyenmai = await _context.CtKhuyenmais
                .Include(c => c.MakhNavigation)
                .Include(c => c.MakmNavigation)
                .FirstOrDefaultAsync(m => m.Makm == id);
            if (ctKhuyenmai == null)
            {
                return NotFound();
            }

            return View(ctKhuyenmai);
        }

        // POST: CtKhuyenmais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctKhuyenmai = await _context.CtKhuyenmais.FindAsync(id);
            if (ctKhuyenmai != null)
            {
                _context.CtKhuyenmais.Remove(ctKhuyenmai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtKhuyenmaiExists(int id)
        {
            return _context.CtKhuyenmais.Any(e => e.Makm == id);
        }
    }
}
