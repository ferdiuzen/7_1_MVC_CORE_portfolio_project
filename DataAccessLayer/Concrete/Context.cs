using EntityLayer.Concrete;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<CustomerUser,CustomerRole,int>
    {
          protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreProjeDB_3;integrated security=true");
        }


        public DbSet<About> Abouts { get; set; } //Db Set yaparak Entity üzerinden veri tabanında "Abouts" isimli bir tablo oluşturmanın alt yapısı kuruldu, Migration işlemi yapıldığında bu tablo oluşacaktır
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }

        public DbSet<Skill> Skills { get; set; }


        public DbSet<SocialMedia> SocialMedias { get; set; }

        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<Test> Test { get; set; }
    }
}
