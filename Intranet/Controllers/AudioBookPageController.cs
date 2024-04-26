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
    public class AudioBookPageController : Controller
    {
        private readonly DatabaseContext _context;

        public AudioBookPageController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: AudioBookPage
        public async Task<IActionResult> Index()
        {
            var databaseContext = _context.ListenAudioBookPages.Include(l => l.Book);
            return View(await databaseContext.ToListAsync());
        }

        // GET: AudioBookPage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listenAudioBookPage = await _context.ListenAudioBookPages
                .Include(l => l.Book)
                .FirstOrDefaultAsync(m => m.AudioPageId == id);
            if (listenAudioBookPage == null)
            {
                return NotFound();
            }

            return View(listenAudioBookPage);
        }

        // GET: AudioBookPage/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description");
            return View();
        }

        // POST: AudioBookPage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AudioPageId,AudioUrl,BookId")] ListenAudioBookPage listenAudioBookPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listenAudioBookPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", listenAudioBookPage.BookId);
            return View(listenAudioBookPage);
        }

        // GET: AudioBookPage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listenAudioBookPage = await _context.ListenAudioBookPages.FindAsync(id);
            if (listenAudioBookPage == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", listenAudioBookPage.BookId);
            return View(listenAudioBookPage);
        }

        // POST: AudioBookPage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AudioPageId,AudioUrl,BookId")] ListenAudioBookPage listenAudioBookPage)
        {
            if (id != listenAudioBookPage.AudioPageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listenAudioBookPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListenAudioBookPageExists(listenAudioBookPage.AudioPageId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Description", listenAudioBookPage.BookId);
            return View(listenAudioBookPage);
        }

        // GET: AudioBookPage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listenAudioBookPage = await _context.ListenAudioBookPages
                .Include(l => l.Book)
                .FirstOrDefaultAsync(m => m.AudioPageId == id);
            if (listenAudioBookPage == null)
            {
                return NotFound();
            }

            return View(listenAudioBookPage);
        }

        // POST: AudioBookPage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listenAudioBookPage = await _context.ListenAudioBookPages.FindAsync(id);
            if (listenAudioBookPage != null)
            {
                _context.ListenAudioBookPages.Remove(listenAudioBookPage);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListenAudioBookPageExists(int id)
        {
            return _context.ListenAudioBookPages.Any(e => e.AudioPageId == id);
        }
    }
}
