using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AnimeShop.Models
{
    public class Fotograf
    {
        public int Id { get; set; }
        public string ResimAd { get; set; }
        public int? UrunId { get; set; }
        [ForeignKey("UrunId")]
        public Fotograf UrunIsmi { get; set; }
    }
}
