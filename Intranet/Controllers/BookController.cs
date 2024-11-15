using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.DATA.BookScheme;

namespace Intranet.Controllers
{
    public class BookController : Controller
    {
        private readonly DatabaseContext _context;

        public BookController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Books.Include(b => b.Author).Include(b => b.BookType).Include(b => b.Genre);
            return View(await databaseContext.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookType)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["IdAuthor"] = new SelectList(from x in _context.Authors
                select new
                {
                    ID = x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                },
                "ID", "FullName");
            ViewData["IdBookType"] = new SelectList(_context.BookTypes, "BookTypeId", "BookTypeName");
            ViewData["IdGenre"] = new SelectList(_context.Genres, "GenreId", "Name");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("BookId,Title,Description,image,ReadCount,IdAuthor,IdBookType,IdGenre,BookNewsCardId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();

                foreach (var error in errors)
                {
                    foreach (var er in error)
                    {
                        Debug.WriteLine(er.ErrorMessage);
                    }
                }
            }

            ViewData["IdAuthor"] = new SelectList(from x in _context.Authors
                select new
                {
                    ID = x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                },
                "ID", "FullName", book.IdAuthor);
            ViewData["IdBookType"] = new SelectList(_context.BookTypes, "BookTypeId", "BookTypeName", book.IdBookType);
            ViewData["IdGenre"] = new SelectList(_context.Genres, "GenreId", "Name", book.IdGenre);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewData["IdAuthor"] = new SelectList(from x in _context.Authors
                select new
                {
                    ID = x.AuthorId,
                    FullName = x.Name + " " + x.Surname
                },
                "ID", "FullName", book.IdAuthor);
            ViewData["IdBookType"] = new SelectList(_context.BookTypes, "BookTypeId", "BookTypeName", book.IdBookType);
            ViewData["IdGenre"] = new SelectList(_context.Genres, "GenreId", "Name", book.IdGenre);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("BookId,Title,Description,image,ReadCount,IdAuthor,IdBookType,IdGenre,BookNewsCardId")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            else
            {
                var errors = ModelState.Select(x => x.Value.Errors)
                    .Where(y=>y.Count>0)
                    .ToList();

                foreach (var error in errors)
                {
                    foreach (var er in error)
                    {
                        Debug.WriteLine(er.ErrorMessage);
                    }
                }
            }

            ViewData["IdAuthor"] = new SelectList(_context.Authors, "AuthorId", "Name", book.IdAuthor);
            ViewData["IdBookType"] = new SelectList(_context.BookTypes, "BookTypeId", "BookTypeName", book.IdBookType);
            ViewData["IdGenre"] = new SelectList(_context.Genres, "GenreId", "Name", book.IdGenre);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookType)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}