using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.DATA.Library;

namespace Intranet.Controllers
{
    public class BookReadPageController : Controller
    {
        private readonly DatabaseContext _context;

        public BookReadPageController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookReadPage
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.ReadOnlineBooks.Include(r => r.Book);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookReadPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readOnlineBook = await _context.ReadOnlineBooks
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReadOnlineId == id);
            if (readOnlineBook == null)
            {
                return NotFound();
            }

            return View(readOnlineBook);
        }

        // GET: BookReadPage/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            return View();
        }

        // POST: BookReadPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReadOnlineId,BookId")] ReadOnlineBook readOnlineBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(readOnlineBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", readOnlineBook.BookId);
            return View(readOnlineBook);
        }

        // GET: BookReadPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readOnlineBook = await _context.ReadOnlineBooks.FindAsync(id);
            if (readOnlineBook == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", readOnlineBook.BookId);
            return View(readOnlineBook);
        }

        // POST: BookReadPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReadOnlineId,BookId")] ReadOnlineBook readOnlineBook)
        {
            if (id != readOnlineBook.ReadOnlineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(readOnlineBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReadOnlineBookExists(readOnlineBook.ReadOnlineId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", readOnlineBook.BookId);
            return View(readOnlineBook);
        }

        // GET: BookReadPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var readOnlineBook = await _context.ReadOnlineBooks
                .Include(r => r.Book)
                .FirstOrDefaultAsync(m => m.ReadOnlineId == id);
            if (readOnlineBook == null)
            {
                return NotFound();
            }

            return View(readOnlineBook);
        }

        // POST: BookReadPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var readOnlineBook = await _context.ReadOnlineBooks.FindAsync(id);
            if (readOnlineBook != null)
            {
                _context.ReadOnlineBooks.Remove(readOnlineBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReadOnlineBookExists(int id)
        {
            return _context.ReadOnlineBooks.Any(e => e.ReadOnlineId == id);
        }
    }
}
