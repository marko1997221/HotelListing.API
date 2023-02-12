namespace HotelListing.Contracts
{
    public interface IGenericContract<T> where T : class
    { 
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int? id);
        Task<T> CreateAsync(T entyty);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entyty);

        Task<bool> Exist(int id);   


    }
}
