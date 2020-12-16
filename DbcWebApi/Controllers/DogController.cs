using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DbcWebApi.Entities;
using DbcWebApi.Models.Dogs;
using DbcWebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Helpers;

namespace DbcWebApi.Controllers
{
    [Route("[controller]")]
    public class DogController : Controller
    {
        private readonly IDogRepository dogRepository;
        private readonly IMapper mapper;

        public DogController(IDogRepository dogRepository, IMapper mapper)
        {
            this.dogRepository = dogRepository;
            this.mapper = mapper;
        }
        
        [Authorize]
        [HttpGet("list")]
        public async Task<IActionResult> GetDogs()
        {
            var userId = int.Parse(User.Identity.Name);
            var dogs = await dogRepository.GetAllDogsAsync(userId);
            var model = mapper.Map<IList<DogModel>>(dogs);
            return Ok(model);
        }
        
        [HttpGet("forSale")]
        public async Task<IActionResult> GetDogsForSale()
        {
            var dogs = await dogRepository.GetAllDogsForSaleAsync();
            var model = mapper.Map<IList<DogForSaleModel>>(dogs);
            return Ok(model);
        }
        
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            await dogRepository.DeleteDog(id);
            return Ok();
        }
        
        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateDog([FromBody] UpdateDogModel dogModel)
        {
            await dogRepository.UpdateDogSaleStatusAsync(dogModel.Id, dogModel.Price);
            return Ok();
        }
        
        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> UpdateDog([FromBody] AddDogModel dogModel)
        {
            var userId = int.Parse(User.Identity.Name);
            var dog = mapper.Map<Dog>(dogModel);
            await dogRepository.AddNewDogAsync(userId, dog);
            return Ok();
        }

    }
}