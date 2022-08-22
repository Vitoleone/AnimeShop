using AnimeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimeShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fotograf> Fotograf { get; set; }
        public DbSet<IndirimliUrunler> IndirimliUrunler { get; set; }
        public DbSet<Kampanya> Kampanya { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Siparis> Siparis { get; set; }
        public DbSet<SiparisDetay> SiparisDetay { get; set; }
        public DbSet<Urun> Urun { get; set; }
        public DbSet<AnimeShop.Models.Sepet> Sepet { get; set; }
        public DbSet<AnimeShop.Models.Role> Role { get; set; }
    }
}
