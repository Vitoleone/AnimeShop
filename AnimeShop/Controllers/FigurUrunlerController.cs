using AnimeShop.Data;
using AnimeShop.Models;
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
    public class FigurUrunlerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FigurUrunlerController(ApplicationDbContext context)
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
            return View(urunList.Where(k => k.UrunKategori == "Figür"));
        }
    }
}
