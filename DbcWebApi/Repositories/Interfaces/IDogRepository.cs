using System.Threading.Tasks;
using DbcWebApi.Entities;

namespace DbcWebApi.Repositories.Interfaces
{
    public interface IDogRepository
    {
        public Task<Dog[]> GetAllDogsForSaleAsync();
        public Task<Dog[]> GetAllDogsAsync(int userId);
        public Task AddNewDogAsync(int userId, Dog dog);
        public Task UpdateDogSaleStatusAsync(int dogId, bool isForSale, int cost);
        public Task DeleteDog(int dogId);

    }
}