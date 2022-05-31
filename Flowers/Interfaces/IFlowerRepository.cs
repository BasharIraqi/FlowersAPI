using Flowers.DTO;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flowers.Interfaces
{
    public interface IFlowerRepository
    {
        Task<List<FlowerModel>> GetAllFlowers();
        Task<FlowerModel> GetFlowerByID(int id);
        Task<int> AddFlower(FlowerModel flowerModel);
        Task UpdateFlowerAllProp(int flowerId, FlowerModel modifiedFlower);
       // Task UpdateFlower(int flowerId, JsonPatchDocument flowerModel);
        Task DeleteFlower(int flowerId);
    }
}
