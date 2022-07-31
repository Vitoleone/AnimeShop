using System;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
namespace AnimeShop.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime UyeOlmaTarihi { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public string Sehir { get; set; }
        [NotMapped]
        public string Username
        {
            get
            {
                return Ad + " " + Soyad;
            }
        }

    }


    public enum Cinsiyet
    {
        Kadin,
        Erkek,
        Hiçbiri
    }
}

