using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AnimeShop.Models
{
    public class IndirimliUrunler
    {
        public int Id { get; set; }

        public int? UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Urun Urun { get; set; }
        public double Oran { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }//indirimin olacağı tarih aralığı
        public bool DigerKampanya { get; set; } = true; //ekstra olacak bir kampanya da olursa o da işlensin mi?
    }
}
