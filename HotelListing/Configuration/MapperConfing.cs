using AutoMapper;
using HotelListing.Model;
using HotelListing.Data;
using HotelListing.Model.Country;

namespace HotelListing.Configuration
{
    public class MapperConfing:Profile
    {
        public MapperConfing()
        {
            CreateMap<Country,CreateCountyDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountyDto>().ReverseMap();
        }
    }
}
