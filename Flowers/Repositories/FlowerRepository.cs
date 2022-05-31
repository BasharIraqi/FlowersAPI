using Flowers.DB;
using Flowers.DTO;
using Flowers.Interfaces;
using Flowers.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flowers.Repositories
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowersDbContext _context;

        public FlowerRepository(FlowersDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddFlower(FlowerModel bookModel)
        {
            var flower = new Flower
            {
                Name = bookModel.Name,
                Description = bookModel.Description,
                Color = bookModel.Color,
                Size = bookModel.Size,
                Price = bookModel.Price
            };
            _context.Flowers.Add(flower);
            await _context.SaveChangesAsync();
            return flower.Id;
        }

        public async Task DeleteFlower(int bookId)
        {
            var flower = await _context.Flowers.FindAsync(bookId);

            if (flower != null)
            {
                _context.Flowers.Remove(flower);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<FlowerModel>> GetAllFlowers()
        {
            var flowers = await _context.Flowers.Select(f=>new FlowerModel
            {
                Name = f.Name,
                Description = f.Description,
                Color = f.Color,
                Size = f.Size,
                Price = f.Price
            }).ToListAsync();
            return flowers;
        }

        public async Task<FlowerModel> GetFlowerByID(int id)
        {
            var flower = await _context.Flowers.FindAsync(id);
            if (flower != null)
            {
            return new FlowerModel
            {
                Name = flower.Name,
                Description = flower.Description,
                Color = flower.Color,
                Size = flower.Size,
                Price = flower.Price
            };
            }
            return null;
        }

        public async Task UpdateFlowerAllProp(int flowerId, FlowerModel modifiedFlower)
        {
            var flower = await _context.Flowers.FindAsync(flowerId);
            
            if(flower!=null)
            {

                flower.Name = modifiedFlower.Name;
                flower.Description = modifiedFlower.Description;
                flower.Color = modifiedFlower.Color;
                flower.Size = modifiedFlower.Size;
                flower.Price = modifiedFlower.Price;
                await _context.SaveChangesAsync();
            }
        }

        //public async Task UpdateFlower(int flowerId, JsonPatchDocument flowerModel)
        //{
        //    var flower = await _context.Flowers.FindAsync(flowerId);
        //    if (flower != null)
        //    {
        //        flowerModel.ApplyTo(flower);
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}
