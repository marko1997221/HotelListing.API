using HotelListing.Contracts;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Repository
{
    public class GenericRepositary<T> : IGenericContract<T> where T : class
    {
        readonly HotelListingDbContext context;
        public GenericRepositary(HotelListingDbContext context)
        {
            this.context = context;
        }
        public async Task<T> CreateAsync(T entyty)
        {
            await context.AddAsync(entyty);
            await context.SaveChangesAsync();
            return entyty;
        }

        public async Task DeleteAsync(int id)
        {
            var entity=await context.FindAsync<T>(id);
            context.Remove(entity);
            await context.SaveChangesAsync();

        }

        public async Task<bool> Exist(int id)
        {
            var entity=await GetAsync(id);
            return entity!=null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync<T>();
;
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }
            var country= await context.FindAsync<T>(id);
            return country;
        }

        public async Task UpdateAsync(T entyty)
        {
            context.Update<T>(entyty);
            await context.SaveChangesAsync();
        }
    }
}
