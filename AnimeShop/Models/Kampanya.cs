using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AnimeShop.Models
{
    public class Kampanya
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public DateTime Baslangic { get; set; }
        public DateTime Bitis { get; set; }
        public double IndirimOran { get; set; }
        public double MinimumDeger { get; set; }//mesela bu iki tarih arasında 100 liralık alışverişe %20, 300 liralığa %30 gibi bir kampanya yapmak istersek bunu kullanmalıyız.
    }
}
