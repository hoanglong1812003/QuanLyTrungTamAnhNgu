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
    public class DiemdanhsController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public DiemdanhsController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: Diemdanhs
        public async Task<IActionResult> Index()
        {
            var quanLyTrungTamAnhNguContext = _context.Diemdanhs.Include(d => d.MagvNavigation).Include(d => d.MahvNavigation);
            return View(await quanLyTrungTamAnhNguContext.ToListAsync());
        }

        // GET: Diemdanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemdanh = await _context.Diemdanhs
                .Include(d => d.MagvNavigation)
                .Include(d => d.MahvNavigation)
                .FirstOrDefaultAsync(m => m.Madd == id);
            if (diemdanh == null)
            {
                return NotFound();
            }

            return View(diemdanh);
        }

        // GET: Diemdanhs/Create
        public IActionResult Create()
        {
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv");
            ViewData["Mahv"] = new SelectList(_context.Hocviens, "Mahv", "Mahv");
            return View();
        }

        // POST: Diemdanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madd,Magv,Mahv,Trangthai,Ngayhoc,Cahoc,Ghichu")] Diemdanh diemdanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diemdanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", diemdanh.Magv);
            ViewData["Mahv"] = new SelectList(_context.Hocviens, "Mahv", "Mahv", diemdanh.Mahv);
            return View(diemdanh);
        }

        // GET: Diemdanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemdanh = await _context.Diemdanhs.FindAsync(id);
            if (diemdanh == null)
            {
                return NotFound();
            }
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", diemdanh.Magv);
            ViewData["Mahv"] = new SelectList(_context.Hocviens, "Mahv", "Mahv", diemdanh.Mahv);
            return View(diemdanh);
        }

        // POST: Diemdanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madd,Magv,Mahv,Trangthai,Ngayhoc,Cahoc,Ghichu")] Diemdanh diemdanh)
        {
            if (id != diemdanh.Madd)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diemdanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiemdanhExists(diemdanh.Madd))
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
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", diemdanh.Magv);
            ViewData["Mahv"] = new SelectList(_context.Hocviens, "Mahv", "Mahv", diemdanh.Mahv);
            return View(diemdanh);
        }

        // GET: Diemdanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diemdanh = await _context.Diemdanhs
                .Include(d => d.MagvNavigation)
                .Include(d => d.MahvNavigation)
                .FirstOrDefaultAsync(m => m.Madd == id);
            if (diemdanh == null)
            {
                return NotFound();
            }

            return View(diemdanh);
        }

        // POST: Diemdanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diemdanh = await _context.Diemdanhs.FindAsync(id);
            if (diemdanh != null)
            {
                _context.Diemdanhs.Remove(diemdanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiemdanhExists(int id)
        {
            return _context.Diemdanhs.Any(e => e.Madd == id);
        }
    }
}
