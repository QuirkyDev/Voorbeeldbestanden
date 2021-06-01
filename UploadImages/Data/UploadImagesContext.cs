using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Models;

namespace UploadImages.Data
{
    public class UploadImagesContext: DbContext
    {
        public UploadImagesContext(DbContextOptions<UploadImagesContext> options) : base(options)
        {
        }

        public DbSet<Product> Producten { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }
    }
}
