using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimeShop.Models
{
    public class SiparisDetay
    {
        public int Id { get; set; }

        public int? SiparisId { get; set; }//Foreign keylerde eşleşme olmazsa diye null olabilme ihtimaline izin verdik
        [ForeignKey("SiparisId")]
        public Siparis Siparis { get; set; }

        public int UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Urun Urun { get; set; }

        public double Miktar { get; set; }
        public double Fiyat { get; set; }

        [NotMapped]//bunu yazıyorsak veritabanında aşağıdaki alanı oluşturmaz yani ücreti oluşturmayacaz çünkü veritabanındaki 2 değişkenden türüyor.
        public double Ucret
        {
            get
            {
                return Fiyat * Miktar;
            }
        }
    }
}
