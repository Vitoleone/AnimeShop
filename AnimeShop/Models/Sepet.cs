using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AnimeShop.Models
{
    //2.Ders
    public class Sepet
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Urun Urun { get; set; }

        public string MusteriId { get; set; }//Musteri nin id primary key i string olarak tutulduğundan string dedik.
        [ForeignKey("MusteriId")]
        public ApplicationUser ApplicationUser { get; set; }

        public double Miktar { get; set; }
        public double Fiyat { get; set; }
        public bool SiparisOk { get; set; } = false;

        [NotMapped]
        public double Ucret
        {
            get
            {
                return Fiyat * Miktar;
            }
        }

    }
}
