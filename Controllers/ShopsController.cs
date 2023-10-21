using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReactAspCrud.Models;

namespace ReactAspCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly ShopDbContext _ShopDbContext;
        public ShopsController(ShopDbContext ShopDbContext)
        {
            _ShopDbContext = ShopDbContext;

            
        }
        [HttpGet]
        [Route("GetShop")]
        public async Task<IEnumerable<Shop>> GetShop()
        {
            return await _ShopDbContext.shops.ToListAsync();
        }

        [HttpPost]
        [Route("AddShop")]
        public async Task<Shop> AddStudent(Shop objShop)
        {
            _ShopDbContext.shops.Add(objShop);
            await _ShopDbContext.SaveChangesAsync();
            return objShop;
        }

        [HttpPatch]
        [Route("UpdateShop/{id}")]
        public async Task<Shop> UpdateStudent(Shop objShop)
        {
            _ShopDbContext.Entry(objShop).State = EntityState.Modified;
            await _ShopDbContext.SaveChangesAsync();
            return objShop;
        }

        [HttpDelete]
        [Route("DeleteShop/{id}")]
        public bool DeleteShop(int id)
        {
            bool a = false;
            var Shop = _ShopDbContext.shops.Find(id);
            if (Shop != null)
            {
                a = true;
                _ShopDbContext.Entry( Shop).State = EntityState.Deleted;
                _ShopDbContext.SaveChanges();
            }
            else
            {
                a = false;
            }
            return a;
        }
    }
}
