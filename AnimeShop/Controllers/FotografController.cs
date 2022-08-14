using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeShop.Data;
using AnimeShop.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AnimeShop.Controllers
{
    public class FotografController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnviroment;

        public FotografController(ApplicationDbContext context, IWebHostEnvironment hostingEnviroment)
        {
            _context = context;
            _hostingEnviroment = hostingEnviroment;
        }

        // GET: Fotograf
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Fotograf.Include(f => f.Urun);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Fotograf/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotograf = await _context.Fotograf
                .Include(f => f.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotograf == null)
            {
                return NotFound();
            }

            return View(fotograf);
        }

        // GET: Fotograf/Create
        public IActionResult Create()
        {
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad");
            return View();
        }

        // POST: Fotograf/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResimAd,UrunId")] Fotograf fotograf)
        {
            if (ModelState.IsValid)
            {
                //WebHostEnvironment

                string webRootPath = _hostingEnviroment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images");
                var extension = Path.GetExtension(files[0].FileName);//yüklenen resim dosyasının uzantısı

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                fotograf.ResimAd = @"/images" + fileName + extension;

                //***************
                _context.Add(fotograf);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", fotograf.UrunId);
            return View(fotograf);
        }

        // GET: Fotograf/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotograf = await _context.Fotograf.FindAsync(id);
            if (fotograf == null)
            {
                return NotFound();
            }
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", fotograf.UrunId);
            return View(fotograf);
        }

        // POST: Fotograf/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResimAd,UrunId")] Fotograf fotograf)
        {
            if (id != fotograf.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fotograf);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FotografExists(fotograf.Id))
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
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Ad", fotograf.UrunId);
            return View(fotograf);
        }

        // GET: Fotograf/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fotograf = await _context.Fotograf
                .Include(f => f.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fotograf == null)
            {
                return NotFound();
            }

            return View(fotograf);
        }

        // POST: Fotograf/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fotograf = await _context.Fotograf.FindAsync(id);
            _context.Fotograf.Remove(fotograf);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FotografExists(int id)
        {
            return _context.Fotograf.Any(e => e.Id == id);
        }
    }
}
