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

        public miniDbContext(DbContextOptions<miniDbContext> options):base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().Property(cu => cu.FirstName).IsRequired()
                                                                      .HasMaxLength(150);


                                                                        
        }
    }
}
