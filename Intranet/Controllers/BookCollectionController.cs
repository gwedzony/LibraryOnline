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
    public class BookCollectionController : Controller
    {
        private readonly DatabaseContext _context;

        public BookCollectionController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookCollection
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.BookCollections.Include(b => b.Book).Include(b => b.Collections);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookCollection/Details/5
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

        // GET: BookCollection/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName");
            return View();
        }

        // POST: BookCollection/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,CollectionId,Book,Collections")] BookCollection bookCollection)
        {

            var book = await _context.Books.FirstOrDefaultAsync(x => x.BookId == bookCollection.BookId);
            var collection = await _context.Collections.FirstOrDefaultAsync(c => c.CollectionId == bookCollection.CollectionId);
            
            bookCollection.Book = book;
            bookCollection.Collections = collection;
            
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

        // GET: BookCollection/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
       
            var bookCollection = await _context.BookCollections.FirstOrDefaultAsync(x=>x.CollectionId == id);
     
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookCollection.BookId);
            ViewData["CollectionId"] = new SelectList(_context.Collections, "CollectionId", "CollectionName", bookCollection.CollectionId);
            return View(bookCollection);
        }

        // POST: BookCollection/Edit/5
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

        // GET: BookCollection/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookCollection = await _context.BookCollections
                .Include(b => b.Book)
                .Include(b => b.Collections)
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            
     
            return View(bookCollection);
        }

        // POST: BookCollection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int BookId, int CollectionId)
        {
            var bookCollection = await _context.BookCollections.FirstOrDefaultAsync(collection => collection.BookId == BookId && collection.CollectionId == CollectionId);
            
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
