using Microsoft.EntityFrameworkCore;

namespace HotelListing.Data
{
    public class HotelListingDbContext:DbContext
    {
        public HotelListingDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id =1,
                    Name ="Serbia",
                    ShortName ="Srb"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Greec",
                     ShortName = "Grb"
                 },
                 new Country
                 {
                     Id = 3,
                     Name = "Bahamas",
                     ShortName = "BS"
                 }
                );
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                Id=1,
                Name="Plaza",
                Address="Novi Bg 1",
                CountryId=1,
                Rating=3.5
            },
            new Hotel
            {
                Id = 2,
                Name = "Kalasnikovb",
                Address = "Gunduliceva 5",
                CountryId = 3,
                Rating = 4.5
            },
            new Hotel
            {
                Id = 3,
                Name = "Dabi",
                Address = "Zlatiborska 3 Krusevac",
                CountryId = 2,
                Rating = 5.5
            });
        }
    }
}
