using System.Linq;
using System.Threading.Tasks;
using DbcWebApi.Data;
using DbcWebApi.Entities;
using DbcWebApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbcWebApi.Repositories.Implementation
{
    public class DogRepository : IDogRepository
    {
        private readonly DataContext context;

        public DogRepository(DataContext context)
        {
            this.context = context;
        }
        
        public Task<Dog[]> GetAllDogsForSaleAsync()
        {
            return context.Dogs.Where(item=>item.IsForSale).Include(item=>item.Owner).ToArrayAsync();
        }

        public Task<Dog[]> GetAllDogsAsync(int userId)
        {
            return context.Dogs.Include(item=>item.Owner).Where(item=>item.Owner.Id == userId).ToArrayAsync();
        }

        public async Task AddNewDogAsync(int userId, Dog dog)
        {
            var owner = await context.Users.FindAsync(userId);
            dog.Owner = owner;
            await context.Dogs.AddAsync(dog);
            owner.Dogs.Add(dog);
            await context.SaveChangesAsync();
        }

        public async Task UpdateDogSaleStatusAsync(int dogId, int cost)
        {
            var dog = await context.Dogs.FindAsync(dogId);
            dog.Price = cost;
            dog.IsForSale = true;
            await context.SaveChangesAsync();
        }

        public async Task DeleteDog(int dogId)
        {
            var dog = await context.Dogs.FindAsync(dogId);
            context.Dogs.Remove(dog);
            await context.SaveChangesAsync();
        }
    }
}