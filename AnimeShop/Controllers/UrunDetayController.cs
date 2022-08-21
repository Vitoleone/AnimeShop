using AnimeShop.Data;
using AnimeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeShop.Controllers
{
    public class UrunDetayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UrunDetayController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UrunDetay(int id)
        {
            var urun = _context.Urun.Find(id);
            var urunList = (from u in _context.Urun
                            join k in _context.Kategori on urun.KategoriId equals k.Id
                            join f in _context.Fotograf on urun.Id equals f.UrunId
                            join i in _context.IndirimliUrunler on urun.Id equals i.UrunId
                            select new UrunDTO
                            {
                                UrunId = urun.Id,
                                UrunAdi = urun.Ad,
                                UrunFiyat = urun.Fiyat,
                                UrunFotograf = f.ResimAd,
                                UrunMiktar = urun.Miktar,
                                UrunKategori = k.Ad,
                                UrunIndirimOrani = i.Oran,
                                UrunAciklamasi = urun.Aciklama

                            }).ToList();
            
          

           
            
            return View(urunList);
        }
    }
}
