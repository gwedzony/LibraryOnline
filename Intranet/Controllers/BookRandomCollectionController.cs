using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.DATA.CMS;

namespace Intranet.Controllers
{
    public class BookRandomCollectionController : Controller
    {
        private readonly DatabaseContext _context;

        public BookRandomCollectionController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookRandomCollection
        public async Task<IActionResult> Index()
        {
            return View(await _context.RandomCollections.ToListAsync());
        }

        // GET: BookRandomCollection/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRandomCollections = await _context.RandomCollections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookRandomCollections == null)
            {
                return NotFound();
            }

            return View(bookRandomCollections);
        }

        // GET: BookRandomCollection/Create
        public IActionResult Create()
        {
            ViewBag.Collections = new SelectList(_context.Collections,"CollectionId");
            
            return View();
        }

        // POST: BookRandomCollection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Collections")] BookRandomCollections bookRandomCollections)
        {

            //bookRandomCollections.Collections.Add("Collections");
            
            if (ModelState.IsValid)
            {
                _context.Add(bookRandomCollections);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookRandomCollections);
        }

        // GET: BookRandomCollection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRandomCollections = await _context.RandomCollections.FindAsync(id);
            if (bookRandomCollections == null)
            {
                return NotFound();
            }
            return View(bookRandomCollections);
        }

        // POST: BookRandomCollection/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] BookRandomCollections bookRandomCollections)
        {
            if (id != bookRandomCollections.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookRandomCollections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookRandomCollectionsExists(bookRandomCollections.Id))
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
            return View(bookRandomCollections);
        }

        // GET: BookRandomCollection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookRandomCollections = await _context.RandomCollections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookRandomCollections == null)
            {
                return NotFound();
            }

            return View(bookRandomCollections);
        }

        // POST: BookRandomCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookRandomCollections = await _context.RandomCollections.FindAsync(id);
            if (bookRandomCollections != null)
            {
                _context.RandomCollections.Remove(bookRandomCollections);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookRandomCollectionsExists(int id)
        {
            return _context.RandomCollections.Any(e => e.Id == id);
        }
    }
}
