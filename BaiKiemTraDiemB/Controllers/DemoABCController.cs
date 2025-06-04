using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiKiemTraDiemB.Data;
using BaiKiemTraDiemB.Models;

namespace BaiKiemTraDiemB.Controllers
{
    public class DemoABCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DemoABCController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Demoabc
        public async Task<IActionResult> Index()
        {
            return View(await _context.DemoABCs.ToListAsync());
        }

        // GET: Demoabc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.DemoABC
                .FirstOrDefaultAsync(m => m.Id == id);
            if (demoabc == null)
            {
                return NotFound();
            }

            return View(demoabc);
        }

        // GET: Demoabc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Demoabc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Score")] DemoABC demoABC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demoABC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demoABC);
        }

        // GET: Demoabc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.DemoABC.FindAsync(id);
            if (demoabc == null)
            {
                return NotFound();
            }
            return View(demoabc);
        }

        // POST: Demoabc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Score")] DemoABC demoABC)
        {
            if (id != DemoABC.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demoABC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoABCExists(demoABC.Id))
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
            return View(demoABC);
        }

        private bool DemoABCExists(string id)
        {
            throw new NotImplementedException();
        }

        // GET: Demoabc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoabc = await _context.DemoABC .FirstOrDefaultAsync(m => m.Id == id);
                
            if (demoabc == null)
            {
                return NotFound();
            }

            return View(demoabc);
        }

        // POST: Demoabc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var demoabc = await _context.DemoABCs.FindAsync(id);
            if (demoabc != null)
            {
                _context.DemoABCs.Remove(demoabc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoabcExists(int id)
        {
            return _context.DemoABC.Any(e => e.Id == id);
        }
    }
}