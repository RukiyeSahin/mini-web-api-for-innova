using Microsoft.EntityFrameworkCore;
using mini.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini.Data.Data
{
    public class miniDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public miniDbContext(DbContextOptions<miniDbContext> options) : base(options)
        {
           // this.Database.
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(cu => cu.FirstName).IsRequired()
                                                                      .HasMaxLength(150);


            modelBuilder.Entity<Product>().HasOne(x => x.Category)
                                          .WithMany(c => c.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasData(new Category[] {
              new Category{ Id=1, Name="Elektronik"},
              new Category { Id=2, Name = "Kozmetik"}
            });



            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                 new Product { Id=1, Name = "Ekran Kartı", Price=1500, CategoryId=1},
                 new Product { Id=2, Name = "Klave & Mouse", Price=350, CategoryId =1},
                 new Product { Id=3, Name = "RAM", Price=1330, CategoryId =1},
                 new Product{ Id=4, Name ="Şampuan", Price=25, CategoryId=2}
            });
            /*
             *   Products= new List<Product>{
                                new Product { Name = "Ekran Kartı", Price=1500, CategoryId=1},
                                new Product { Name = "Klave & Mouse", Price=350, CategoryId =1},
                                new Product { Name = "RAM", Price=1330, CategoryId =1},


                            }

             Products = new List<Product>
                            {
                                new Product{ Name ="Şampuan", Price=25, CategoryId=2}
                            }
             */





        }
    }
}
