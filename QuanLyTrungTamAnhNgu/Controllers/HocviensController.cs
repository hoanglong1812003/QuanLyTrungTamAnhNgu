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
    public class HocviensController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public HocviensController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: Hocviens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hocviens.ToListAsync());
        }

        // GET: Hocviens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocviens
                .FirstOrDefaultAsync(m => m.Mahv == id);
            if (hocvien == null)
            {
                return NotFound();
            }

            return View(hocvien);
        }

        // GET: Hocviens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hocviens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mahv,Tenhv,Ngaysinh,Gioitinh,Diachi,Socccd,Sdt,Email")] Hocvien hocvien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hocvien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hocvien);
        }

        // GET: Hocviens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocviens.FindAsync(id);
            if (hocvien == null)
            {
                return NotFound();
            }
            return View(hocvien);
        }

        // POST: Hocviens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mahv,Tenhv,Ngaysinh,Gioitinh,Diachi,Socccd,Sdt,Email")] Hocvien hocvien)
        {
            if (id != hocvien.Mahv)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hocvien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HocvienExists(hocvien.Mahv))
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
            return View(hocvien);
        }

        // GET: Hocviens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hocvien = await _context.Hocviens
                .FirstOrDefaultAsync(m => m.Mahv == id);
            if (hocvien == null)
            {
                return NotFound();
            }

            return View(hocvien);
        }

        // POST: Hocviens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hocvien = await _context.Hocviens.FindAsync(id);
            if (hocvien != null)
            {
                _context.Hocviens.Remove(hocvien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HocvienExists(int id)
        {
            return _context.Hocviens.Any(e => e.Mahv == id);
        }
    }
}
