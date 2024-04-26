using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Database.Context;
using Database.DATA.CMS;

namespace Intranet.Controllers
{
    public class BookPreviewController : Controller
    {
        private readonly DatabaseContext _context;

        public BookPreviewController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BookPreview
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.Bookpreviews.Include(b => b.Book);
            return View(await databaseContext.ToListAsync());
        }

        // GET: BookPreview/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPreview = await _context.Bookpreviews
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.PreviewId == id);
            if (bookPreview == null)
            {
                return NotFound();
            }

            return View(bookPreview);
        }

        // GET: BookPreview/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            return View();
        }

        // POST: BookPreview/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PreviewId,SmallCoverImg,PdfUrl,AudioUrl,BookId")] BookPreview bookPreview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPreview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPreview.BookId);
            return View(bookPreview);
        }

        // GET: BookPreview/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPreview = await _context.Bookpreviews.FindAsync(id);
            if (bookPreview == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPreview.BookId);
            return View(bookPreview);
        }

        // POST: BookPreview/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PreviewId,SmallCoverImg,PdfUrl,AudioUrl,BookId")] BookPreview bookPreview)
        {
            if (id != bookPreview.PreviewId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPreview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPreviewExists(bookPreview.PreviewId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", bookPreview.BookId);
            return View(bookPreview);
        }

        // GET: BookPreview/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPreview = await _context.Bookpreviews
                .Include(b => b.Book)
                .FirstOrDefaultAsync(m => m.PreviewId == id);
            if (bookPreview == null)
            {
                return NotFound();
            }

            return View(bookPreview);
        }

        // POST: BookPreview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPreview = await _context.Bookpreviews.FindAsync(id);
            if (bookPreview != null)
            {
                _context.Bookpreviews.Remove(bookPreview);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPreviewExists(int id)
        {
            return _context.Bookpreviews.Any(e => e.PreviewId == id);
        }
    }
}
