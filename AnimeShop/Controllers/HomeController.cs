using AnimeShop.Data;
using AnimeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var urunList = (from u in _context.Urun
                            join k in _context.Kategori on u.KategoriId equals k.Id
                            join f in _context.Fotograf on u.Id equals f.UrunId
                            join i in _context.IndirimliUrunler on u.Id equals i.UrunId
                            select new UrunDTO
                            {
                                UrunId = u.Id,
                                UrunAdi = u.Ad,
                                UrunFiyat = u.Fiyat,
                                UrunFotograf = f.ResimAd,
                                UrunMiktar = u.Miktar,
                                UrunKategori = k.Ad,
                                UrunIndirimOrani = i.Oran


                            }).ToList();
            return View(urunList);
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
