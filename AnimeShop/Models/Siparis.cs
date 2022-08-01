using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeShop.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public string MusteriId { get; set; }//Musteri nin id primary key i string olarak tutulduğundan string dedim.
        [ForeignKey("MusteriId")]
        public ApplicationUser ApplicationUser { get; set; }//bunu da foreign için ekledim
        public DateTime SiparisTarihi { get; set; }
        public DateTime? GondermeTarihi { get; set; }
        public DateTime? TeslimTarihi { get; set; }
        public DateTime? IadeTarihi { get; set; }
        public string KargoFirma { get; set; }
        public double KargoUcreti { get; set; }
        public double ToplamUcret { get; set; }
        public double Indirim { get; set; }
        public SiparisDurumu SiparisDurumu { get; set; }
        public OdemeDurumu OdemeDurumu { get; set; }

        public string SiparisKodu { get; set; }
        public string KargoTakipNo { get; set; }
        public string Aciklama { get; set; }


    }
    public enum SiparisDurumu
    {
        Hazirlaniyor,
        KargoyaVerildi,
        TeslimEdildi,
        İadeEdildi
    }
    public enum OdemeDurumu
    {
        KrediKarti,
        Eft,
        Havale,
        KapidaOdeme,
        Onaylanmadi
    }
}

