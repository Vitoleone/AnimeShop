using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeShop.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public double Fiyat { get; set; }
        public double Miktar { get; set; }
        public string Aciklama { get; set; }
        public string UretimYeri { get; set; }
        public int? KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public Kategori Kategori { get; set; }
        public ICollection<Fotograf> Fotograf { get; set; }
    }
}

