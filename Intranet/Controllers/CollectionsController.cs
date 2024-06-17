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
using Database.DATA.CMS;

namespace Intranet.Controllers
{
    public class CollectionsController : Controller
    {
        private readonly DatabaseContext _context;

        public CollectionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Collections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Collections.ToListAsync());
        }

        // GET: Collections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (collections == null)
            {
                return NotFound();
            }

            return View(collections);
        }

        // GET: Collections/Create
        /*public IActionResult Create()
        {
            return View();
        }
        */

        // POST: Collections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectionId,CollectionName")] Collections collections)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collections);
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
                    Debug.WriteLine(error);
                }
            }
            return View(collections);
        }

        // GET: Collections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections.FindAsync(id);
            if (collections == null)
            {
                return NotFound();
            }
            return View(collections);
        }
    

        // POST: Collections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectionId,CollectionName")] Collections collections)
        {
            if (id != collections.CollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collections);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionsExists(collections.CollectionId))
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
            return View(collections);
        }

        // GET: Collections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collections = await _context.Collections
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (collections == null)
            {
                return NotFound();
            }

            return View(collections);
        }

        // POST: Collections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collections = await _context.Collections.FindAsync(id);
            if (collections != null)
            {
                _context.Collections.Remove(collections);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollectionsExists(int id)
        {
            return _context.Collections.Any(e => e.CollectionId == id);
        }
    }
}
