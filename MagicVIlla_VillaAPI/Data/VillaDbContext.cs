using MagicVIlla_VillaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVIlla_VillaAPI.Data
{
    public class VillaDbContext(DbContextOptions<VillaDbContext> options) : DbContext(options)
    {
        public DbSet<Villa> Villas { get; set; }
        public DbSet<VillaNumber> VillaNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(

               new Villa { Id = 1, ImageUrl = "Image" ,Name = "Bandon State Airport", Details = "Supplement Left Temporomandibular Joint with Synthetic Substitute, Open Approach", Sqft = 123,  Rate = 4.48,  Amenity = "Flatley Inc", Occupancy = 1, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
               new Villa { Id = 2, ImageUrl = "Image", Name = "Taree Airport", Details = "Division of Oculomotor Nerve, Percutaneous Approach", Sqft = 183,  Rate = 8.01,  Amenity = "Kreiger, Marquardt and Jast", Occupancy = 2, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
               new Villa { Id = 3, ImageUrl = "Image", Name = "Dunhuang Airport", Details = "Revision of Autologous Tissue Substitute in Right Eye, Open Approach", Sqft = 134,  Rate = 0.99,  Amenity = "Douglas, Smith and Herman", Occupancy = 3, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
               new Villa { Id = 4, ImageUrl = "Image", Name = "Inisheer Aerodrome", Details = "Introduction of Other Therapeutic Substance into Female Reproductive, Via Natural or Artificial Opening", Sqft = 187,  Rate = 1.24,  Amenity = "Yost, Parker and Quigley", Occupancy = 4, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now },
               new Villa { Id = 5, ImageUrl = "Image", Name = "Wabush Airport", Details = "Stereotactic Gamma Beam Radiosurgery of Trachea", Sqft = 74,  Rate = 9.68,  Amenity = "Dickinson-Greenholt", Occupancy = 5, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now }
               
            );
        }

    }
}
