using AnimeShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimeShop.Components
{
    public class KategoriUrun:ViewComponent
    {

        private readonly ApplicationDbContext _context;
        public KategoriUrun(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke(int id)//bütün viewComponentlerde tanımlanır, id hangi ürünlerin kategorisini getireceğimizi belirler.
        {
            var liste = _context.Urun.Include(p => p.Kategori).Where(x => x.KategoriId == id);//Kategori tablosunda olan ürünleri getirir
            return View(liste);//liste modelini view e gönderir.
            //bu viewcomponent in html sini views içerisindeki Shared altındaki Components klasörüne KategoriUrun diye başka bir klasör oluşturur ve orada tutarız
        }
    }
}
