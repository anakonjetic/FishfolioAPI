using FishfolioAPI.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FishfolioAPI.Controllers
{
    [ApiController]
    [Route("api/fishfolio")]
    public class FishFamilyController : Controller
    {
        private FishfolioDbContext _dbContext;

        public FishFamilyController(FishfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Route("fish/fishfamily/compatible/{id}")]
        public IActionResult Get(int id)
        {
            var fishFamiliesCompatible = this._dbContext.FishFamilyCompatibility
                .Where(f => f.ParentId == id)
                .Select(f => new FishFamilyCompatibilityDTO()
                {
                    ParentId = f.ParentId,
                    CompatibilityId = f.CompatibilityId
                }).AsQueryable();

            if (fishFamiliesCompatible == null)
            {
                return NotFound();
            }

            var fishFamily = this._dbContext.FishFamilies
                .Where(f => fishFamiliesCompatible.Select(ff => ff.CompatibilityId).Contains(f.Id))
                .Select(f => new FishFamilyDTO()
                {
                    Id = f.Id,
                    Name = f.Name
                }).AsQueryable();

            return Ok(fishFamily);

        }

        [Route("fish/fishfamily/incompatible/{id}")]
        public IActionResult Get2(int id)
        {
            var fishFamiliesIncompatible = this._dbContext.FishFamilyIncompatibility
                .Where(f => f.ParentId == id)
                .Select(f => new FishFamilyIncompatibilityDTO()
                {
                    ParentId = f.ParentId,
                    CompatibilityId = f.CompatibilityId
                }).AsQueryable();

            if (fishFamiliesIncompatible == null)
            {
                return NotFound();
            }

            var fishFamily = this._dbContext.FishFamilies
                .Where(f => fishFamiliesIncompatible.Select(ff => ff.CompatibilityId).Contains(f.Id))
                .Select(f => new FishFamilyDTO()
                {
                    Id = f.Id,
                    Name = f.Name
                }).AsQueryable();

            return Ok(fishFamily);

        }


        public class FishFamilyDTO
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }

        public class FishFamilyCompatibilityDTO
        {
            public int ParentId { get; set; }
            public int CompatibilityId { get; set; }
        }

        public class FishFamilyIncompatibilityDTO
        {
            public int ParentId { get; set; }
            public int CompatibilityId { get; set; }
        }

    }
}
