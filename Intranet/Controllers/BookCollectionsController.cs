using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.Data.BookScheme;

namespace Intranet.Controllers
{
    public class BookCollectionsController : Controller
    {
        private readonly DatabaseContext _context;

        public BookCollectionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookCollections
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.BookCollections.Include(b => b.Book).Include(b => b.Collections);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollection = await _context.BookCollections
                .Include(b => b.Book)
                .Include(b => b.Collections)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookCollection == null)
            {
                return NotFound();
            }

            return View(bookCollection);
        }

        // GET: BookCollections/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName");
            return View();
        }

        // POST: BookCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,CollectionId")] BookCollection bookCollection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookCollection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookCollection.BookId);
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName", bookCollection.CollectionId);
            return View(bookCollection);
        }

        // GET: BookCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollection = await _context.BookCollections.FindAsync(id);
            if (bookCollection == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookCollection.BookId);
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName", bookCollection.CollectionId);
            return View(bookCollection);
        }

        // POST: BookCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,CollectionId")] BookCollection bookCollection)
        {
            if (id != bookCollection.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookCollection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookCollectionExists(bookCollection.BookId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookCollection.BookId);
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName", bookCollection.CollectionId);
            return View(bookCollection);
        }

        // GET: BookCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollection = await _context.BookCollections
                .Include(b => b.Book)
                .Include(b => b.Collections)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (bookCollection == null)
            {
                return NotFound();
            }

            return View(bookCollection);
        }

        // POST: BookCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookCollection = await _context.BookCollections.FindAsync(id);
            if (bookCollection != null)
            {
                _context.BookCollections.Remove(bookCollection);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookCollectionExists(int id)
        {
            return _context.BookCollections.Any(e => e.BookId == id);
        }
    }
}
