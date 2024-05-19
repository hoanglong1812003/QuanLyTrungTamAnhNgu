﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyTrungTamAnhNgu.Data;

namespace QuanLyTrungTamAnhNgu.Controllers
{
    public class LichdaysController : Controller
    {
        private readonly QuanLyTrungTamAnhNguContext _context;

        public LichdaysController(QuanLyTrungTamAnhNguContext context)
        {
            _context = context;
        }

        // GET: Lichdays
        public async Task<IActionResult> Index()
        {
            var quanLyTrungTamAnhNguContext = _context.Lichdays.Include(l => l.MagvNavigation).Include(l => l.MalopNavigation);
            return View(await quanLyTrungTamAnhNguContext.ToListAsync());
        }

        // GET: Lichdays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichday = await _context.Lichdays
                .Include(l => l.MagvNavigation)
                .Include(l => l.MalopNavigation)
                .FirstOrDefaultAsync(m => m.Mald == id);
            if (lichday == null)
            {
                return NotFound();
            }

            return View(lichday);
        }

        // GET: Lichdays/Create
        public IActionResult Create()
        {
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv");
            ViewData["Malop"] = new SelectList(_context.Lophocs, "Malop", "Malop");
            return View();
        }

        // POST: Lichdays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mald,Malop,Magv,Tuan,Caday,Ngayday,Ghichu")] Lichday lichday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", lichday.Magv);
            ViewData["Malop"] = new SelectList(_context.Lophocs, "Malop", "Malop", lichday.Malop);
            return View(lichday);
        }

        // GET: Lichdays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichday = await _context.Lichdays.FindAsync(id);
            if (lichday == null)
            {
                return NotFound();
            }
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", lichday.Magv);
            ViewData["Malop"] = new SelectList(_context.Lophocs, "Malop", "Malop", lichday.Malop);
            return View(lichday);
        }

        // POST: Lichdays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mald,Malop,Magv,Tuan,Caday,Ngayday,Ghichu")] Lichday lichday)
        {
            if (id != lichday.Mald)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichdayExists(lichday.Mald))
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
            ViewData["Magv"] = new SelectList(_context.Giangviens, "Magv", "Magv", lichday.Magv);
            ViewData["Malop"] = new SelectList(_context.Lophocs, "Malop", "Malop", lichday.Malop);
            return View(lichday);
        }

        // GET: Lichdays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lichday = await _context.Lichdays
                .Include(l => l.MagvNavigation)
                .Include(l => l.MalopNavigation)
                .FirstOrDefaultAsync(m => m.Mald == id);
            if (lichday == null)
            {
                return NotFound();
            }

            return View(lichday);
        }

        // POST: Lichdays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichday = await _context.Lichdays.FindAsync(id);
            if (lichday != null)
            {
                _context.Lichdays.Remove(lichday);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LichdayExists(int id)
        {
            return _context.Lichdays.Any(e => e.Mald == id);
        }
    }
}
