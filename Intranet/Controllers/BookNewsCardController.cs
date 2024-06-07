using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.DATA.CMS;
using Intranet.Models;

namespace Intranet.Controllers
{
    public class BookNewsCardController : Controller
    {
        private readonly DatabaseContext _context;

        public BookNewsCardController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookNewsCard
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.BookNewsCards.Include(b => b.Book);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookNewsCard/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNewsCard = await _context.BookNewsCards
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookNewsCardId == id);
            if (bookNewsCard == null)
            {
                return NotFound();
            }

            return View(bookNewsCard);
        }

        // GET: BookNewsCard/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            ViewBag.NewestBook = new List<NewestBooksCardsPreview>();
            return View();
        }

        // POST: BookNewsCard/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookNewsCardId,SmallCoverImg,BookLink,WhenCreated,BookId")] BookNewsCard bookNewsCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookNewsCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookNewsCard.BookId);
            return View(bookNewsCard);
        }

        // GET: BookNewsCard/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNewsCard = await _context.BookNewsCards.FindAsync(id);
            if (bookNewsCard == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookNewsCard.BookId);
            return View(bookNewsCard);
        }

        // POST: BookNewsCard/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookNewsCardId,SmallCoverImg,BookLink,WhenCreated,BookId")] BookNewsCard bookNewsCard)
        {
            if (id != bookNewsCard.BookNewsCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookNewsCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookNewsCardExists(bookNewsCard.BookNewsCardId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookNewsCard.BookId);
            return View(bookNewsCard);
        }

        // GET: BookNewsCard/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookNewsCard = await _context.BookNewsCards
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.BookNewsCardId == id);
            if (bookNewsCard == null)
            {
                return NotFound();
            }

            return View(bookNewsCard);
        }

        // POST: BookNewsCard/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookNewsCard = await _context.BookNewsCards.FindAsync(id);
            if (bookNewsCard != null)
            {
                _context.BookNewsCards.Remove(bookNewsCard);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookNewsCardExists(int id)
        {
            return _context.BookNewsCards.Any(e => e.BookNewsCardId == id);
        }
    }
}
