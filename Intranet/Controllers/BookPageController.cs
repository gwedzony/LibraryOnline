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
    public class BookPageController : Controller
    {
        private readonly DatabaseContext _context;

        public BookPageController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookPage
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.BookPages.Include(b => b.Book);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPage = await _context.BookPages
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookPageId == id);
            if (bookPage == null)
            {
                return NotFound();
            }

            return View(bookPage);
        }

        // GET: BookPage/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            return View();
        }

        // POST: BookPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookPageId,BigCoverImg,PdfUrl,BookId")] BookPage bookPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPage.BookId);
            return View(bookPage);
        }

        // GET: BookPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPage = await _context.BookPages.FindAsync(id);
            if (bookPage == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPage.BookId);
            return View(bookPage);
        }

        // POST: BookPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookPageId,BigCoverImg,PdfUrl,BookId")] BookPage bookPage)
        {
            if (id != bookPage.BookPageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPageExists(bookPage.BookPageId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPage.BookId);
            return View(bookPage);
        }

        // GET: BookPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPage = await _context.BookPages
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookPageId == id);
            if (bookPage == null)
            {
                return NotFound();
            }

            return View(bookPage);
        }

        // POST: BookPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPage = await _context.BookPages.FindAsync(id);
            if (bookPage != null)
            {
                _context.BookPages.Remove(bookPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPageExists(int id)
        {
            return _context.BookPages.Any(e => e.BookPageId == id);
        }
    }
}
