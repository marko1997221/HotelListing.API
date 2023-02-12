using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
<<<<<<< HEAD
using HotelListing.Model;
using AutoMapper;
using HotelListing.Model.Country;
using HotelListing.Repository;
using HotelListing.Contracts;
=======
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
<<<<<<< HEAD
  
        readonly IMapper mapper;
        // ovde je bitno da bude interfejs a ne repository
        readonly ICountryInterface repository;

        public CountriesController(ICountryInterface repository , IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            
=======
        private readonly HotelListingDbContext _context;

        public CountriesController(HotelListingDbContext context)
        {
            _context = context;
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
        }

        // GET: api/Countries
        [HttpGet]
<<<<<<< HEAD
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var country = await repository.GetAllAsync();
            var conutryDto=mapper.Map<List<GetCountryDto>>(country);
            return Ok(conutryDto);
=======
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
<<<<<<< HEAD
        public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
        {
            var country = await repository.GetAsync(id);
            var conutryDto= mapper.Map<GetCountryDto>(country);
=======
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);

>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
            if (country == null)
            {
                return NotFound();
            }

<<<<<<< HEAD
            return Ok(conutryDto);
=======
            return country;
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
<<<<<<< HEAD
        public async Task<IActionResult> PutCountry(int id, UpdateCountyDto updateCountyDto)
        {
            if (id != updateCountyDto.Id)
=======
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id)
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
            {
                return BadRequest();
            }

<<<<<<< HEAD
            var counrty = await repository.GetAsync(id);
            //_context.Entry(country).State = EntityState.Modified;
            if (counrty == null)
            {
                return NotFound();
            }
            mapper.Map(updateCountyDto, counrty);
            
            try
            {
                await repository.UpdateAsync(counrty);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
=======
            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult<Country>> PostCountry(CreateCountyDto Modelcountry)
        {
            var country= mapper.Map<Country>(Modelcountry);
            await repository.CreateAsync(country);
=======
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
<<<<<<< HEAD
            var country= await repository.GetAsync(id);
=======
            var country = await _context.Countries.FindAsync(id);
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
            if (country == null)
            {
                return NotFound();
            }
<<<<<<< HEAD
            await repository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await repository.Exist(id);
=======

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
>>>>>>> c42b8e42016132fe641c126614e26bbd7a42eb8f
        }
    }
}
