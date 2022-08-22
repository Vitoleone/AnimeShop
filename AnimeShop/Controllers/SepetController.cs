using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnimeShop.Data;
using AnimeShop.Models;
using System.Web;
using Microsoft.AspNetCore.Identity;


namespace AnimeShop.Controllers
{
    public class SepetController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public SepetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sepet
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sepet.Include(s => s.ApplicationUser).Include(s => s.Urun);
            return View(await applicationDbContext.ToListAsync());
        }
        [Route("/Sepet/SepetEkle/{id}")]
        public async Task<IActionResult> SepeteEkle(int id)
        {
            if(User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var model = _context.Users.FirstOrDefault(x=>x.UserName == kullaniciAdi);
                var u = _context.Urun.Find(id);
                var sepet = _context.Sepet.FirstOrDefault(x => x.ApplicationUser.UserName == model.Email && x.UrunId == id);
                var i = _context.IndirimliUrunler.Find(id);
                if (model != null)
                {
                    if(sepet!=null)
                    {
                        sepet.Miktar++;
                        sepet.Fiyat = Math.Round(u.Fiyat - (u.Fiyat * i.Oran) / 100,2);
                        _context.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    var s = new Sepet
                    {
                        MusteriId = model.Id,
                        UrunId = u.Id,
                        Miktar = 1,
                        Fiyat = Math.Round(u.Fiyat - (u.Fiyat * i.Oran) / 100, 2),


                };
                    
                    
                    _context.Entry(s).State = EntityState.Added;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }
        public async Task<IActionResult> SepettenKaldir(int id)
        {
            var kullaniciAdi = User.Identity.Name;
            var model = _context.Users.FirstOrDefault(x => x.UserName == kullaniciAdi);
            var u = _context.Urun.Find(id);
            var sepet = _context.Sepet.FirstOrDefault(x => x.ApplicationUser.UserName == model.Email && x.UrunId == id);
            var i = _context.IndirimliUrunler.Find(id);
            if (model != null)
            {
                if (sepet != null && sepet.Miktar > 0)
                {
                    sepet.Miktar--;
                    sepet.Fiyat = Math.Round(u.Fiyat - (u.Fiyat * i.Oran) / 100, 2);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    sepet.Miktar = 0;
                    sepet.Fiyat = Math.Round(u.Fiyat - (u.Fiyat * i.Oran) / 100,2);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                var s = new Sepet
                {
                    MusteriId = model.Id,
                    UrunId = u.Id,
                    Miktar = 1,
                    Fiyat = -Math.Round(u.Fiyat - (u.Fiyat * i.Oran) / 100, 2),

            };


                _context.Entry(s).State = EntityState.Deleted;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // GET: Sepet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sepet = await _context.Sepet
                .Include(s => s.ApplicationUser)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sepet == null)
            {
                return NotFound();
            }

            return View(sepet);
        }

        // GET: Sepet/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Id");
            return View();
        }

        // POST: Sepet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunId,MusteriId,Miktar,Fiyat,SiparisOk")] Sepet sepet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sepet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Users, "Id", "Id", sepet.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Id", sepet.UrunId);
            return View(sepet);
        }

        // GET: Sepet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sepet = await _context.Sepet.FindAsync(id);
            if (sepet == null)
            {
                return NotFound();
            }
            ViewData["MusteriId"] = new SelectList(_context.Users, "Id", "Id", sepet.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Id", sepet.UrunId);
            return View(sepet);
        }

        // POST: Sepet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunId,MusteriId,Miktar,Fiyat,SiparisOk")] Sepet sepet)
        {
            if (id != sepet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sepet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SepetExists(sepet.Id))
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
            ViewData["MusteriId"] = new SelectList(_context.Users, "Id", "Id", sepet.MusteriId);
            ViewData["UrunId"] = new SelectList(_context.Urun, "Id", "Id", sepet.UrunId);
            return View(sepet);
        }

        // GET: Sepet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sepet = await _context.Sepet
                .Include(s => s.ApplicationUser)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sepet == null)
            {
                return NotFound();
            }

            return View(sepet);
        }

        // POST: Sepet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sepet = await _context.Sepet.FindAsync(id);
            _context.Sepet.Remove(sepet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SepetExists(int id)
        {
            return _context.Sepet.Any(e => e.Id == id);
        }
    }
}
