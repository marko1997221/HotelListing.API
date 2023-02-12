﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.Data;
using HotelListing.Model;
using AutoMapper;
using HotelListing.Model.Country;
using HotelListing.Repository;
using HotelListing.Contracts;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
  
        readonly IMapper mapper;
        // ovde je bitno da bude interfejs a ne repository
        readonly ICountryInterface repository;

        public CountriesController(ICountryInterface repository , IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var country = await repository.GetAllAsync();
            var conutryDto=mapper.Map<List<GetCountryDto>>(country);
            return Ok(conutryDto);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDto>> GetCountry(int id)
        {
            var country = await repository.GetAsync(id);
            var conutryDto= mapper.Map<GetCountryDto>(country);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(conutryDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountyDto updateCountyDto)
        {
            if (id != updateCountyDto.Id)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<Country>> PostCountry(CreateCountyDto Modelcountry)
        {
            var country= mapper.Map<Country>(Modelcountry);
            await repository.CreateAsync(country);

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country= await repository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await repository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await repository.Exist(id);
        }
    }
}
