using HotelListing.Data;
using HotelListing.Contracts;
namespace HotelListing.Repository
{
    public class CountryRepository : GenericRepositary<Country>, ICountryInterface
    {
        public CountryRepository(HotelListingDbContext context) : base(context)
        {
        }

    }
}
