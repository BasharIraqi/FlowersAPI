using Flowers.DTO;
using Flowers.Interfaces;
using Flowers.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowersController : ControllerBase
    {
        private readonly IFlowerRepository _repository;

        public FlowersController(IFlowerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowerById([FromRoute] int id)
        {
            var flowers = await _repository.GetAllFlowers();
            return Ok(flowers);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddFlower([FromBody] FlowerModel flowerModel)
        {
          var id= await _repository.AddFlower(flowerModel);
            return CreatedAtAction(nameof(GetFlowerById),new { id = id,controller = "flowers" },id);
        }

        [HttpGet]
        public async Task<IActionResult> AllFlowers()
        {
            var flowers = await _repository.GetAllFlowers();
            return Ok(flowers);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlowerById([FromRoute]int id,[FromBody]FlowerModel flowerModel)
        {
            await _repository.UpdateFlowerAllProp(id, flowerModel);

            return Ok();  
        }

        [HttpDelete("{id}")]
        public async Task DeleteFlower(int id)
        {
           await _repository.DeleteFlower(id);
        }
        
        //[HttpPatch("{id}")]
        //public async Task<IActionResult> UpdateFlower([FromRoute] int id, [FromBody] JsonPatchDocument flowerModel)
        //{
        //    await _repository.UpdateFlower(id,flowerModel);

        //    return Ok();
        //}





    }
}
