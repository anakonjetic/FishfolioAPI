using FishfolioAPI.DAL;
using FishfolioAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace FishfolioAPI.Controllers
{
    [ApiController]
    [Route("api/fishfolio")]
    public class FishController : Controller
    {
        private FishfolioDbContext _dbContext;

        public FishController(FishfolioDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [Route("fish")]
        public IActionResult Get()
        {
            var fish = this._dbContext.Fish
                .Select (f => new FishDTO()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    WaterType = new WaterTypeDTO()
                    {
                        Id = f.WaterTypeId,
                        Type = f.WaterType.Type
                    },
                    FishFamily = new FishFamilyDTO()
                    {
                        Id = f.FishFamilyId,
                        Name = f.FishFamily.Name
                    },
                    Habitat = new HabitatDTO()
                    {
                        Id = f.HabitatId,
                        Name = f.Habitat.Name
                    },
                    Image = f.Image,
                    MinSchoolSize = f.MinSchoolSize,
                    AvgSchoolSize = f.AvgSchoolSize,
                    MinAquariumSizeInL = f.MinAquariumSizeInL,
                    Gender = f.Gender,
                    MaxNumberOfSameGender = f.MaxNumberOfSameGender,
                    AvailableInStore = f.AvailableInStore
                }).AsQueryable();

            if(fish == null)
            {
                return NotFound();
            }
            return Ok(fish);

        }

        [Route("fish/habitat")]
        public IActionResult GetH()
        {
            var habitat = this._dbContext.Habitats
                .Select(f => new HabitatDTO()
                {
                    Id = f.Id,
                    Name = f.Name
                }).AsQueryable();

            if (habitat == null)
            {
                return NotFound();
            }
            return Ok(habitat);

        }

        [Route("fish/watertype")]
        public IActionResult GetW()
        {
            var watertype = this._dbContext.WaterTypes
                .Select(f => new WaterTypeDTO()
                {
                    Id = f.Id,
                    Type = f.Type
                }).AsQueryable();

            if (watertype == null)
            {
                return NotFound();
            }
            return Ok(watertype);

        }

        [Route("fish/fishfamilies")]
        public IActionResult GetFF()
        {
            var fishfamily = this._dbContext.FishFamilies
                .Select(f => new FishFamilyDTO()
                {
                    Id = f.Id,
                    Name = f.Name
                }).AsQueryable();

            if (fishfamily == null)
            {
                return NotFound();
            }
            return Ok(fishfamily);

        }


            [Route("fish/{id}")]
        public IActionResult Get(int id)
        {
            var fish = this._dbContext.Fish
                .Where(f => f.Id == id)
                .Select(f => new FishDTO()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    WaterType = new WaterTypeDTO()
                    {
                        Id = f.WaterTypeId,
                        Type = f.WaterType.Type
                    },
                    FishFamily = new FishFamilyDTO()
                    {
                        Id = f.FishFamilyId,
                        Name = f.FishFamily.Name
                    },
                    Habitat = new HabitatDTO()
                    {
                        Id = f.HabitatId,
                        Name = f.Habitat.Name
                    },
                    Image = f.Image,
                    MinSchoolSize = f.MinSchoolSize,
                    AvgSchoolSize = f.AvgSchoolSize,
                    MinAquariumSizeInL = f.MinAquariumSizeInL,
                    Gender = f.Gender,
                    MaxNumberOfSameGender = f.MaxNumberOfSameGender,
                    AvailableInStore = f.AvailableInStore
                }).FirstOrDefault();

            if (fish == null)
            {
                return NotFound();
            }
            return Ok(fish);

        }

        [Route("fish/names/{name}")]
        public IActionResult Get(string name)
        {
            var fish = this._dbContext.Fish
                .Where(f => f.Name.Contains(name))
                .Select(f => new FishDTO()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    WaterType = new WaterTypeDTO()
                    {
                        Id = f.WaterTypeId,
                        Type = f.WaterType.Type
                    },
                    FishFamily = new FishFamilyDTO()
                    {
                        Id = f.FishFamilyId,
                        Name = f.FishFamily.Name
                    },
                    Habitat = new HabitatDTO()
                    {
                        Id = f.HabitatId,
                        Name = f.Habitat.Name
                    },
                    Image = f.Image,
                    MinSchoolSize = f.MinSchoolSize,
                    AvgSchoolSize = f.AvgSchoolSize,
                    MinAquariumSizeInL = f.MinAquariumSizeInL,
                    Gender = f.Gender,
                    MaxNumberOfSameGender = f.MaxNumberOfSameGender,
                    AvailableInStore = f.AvailableInStore
                }).AsQueryable();

            if (fish == null)
            {
                return NotFound();
            }
            return Ok(fish);

        }

        
        [HttpPost]
        [Route("fish")]
        public IActionResult Post(FishDTO fish)
        {
          var waterType = this._dbContext.WaterTypes.Where(w => w.Id == fish.WaterType.Id).FirstOrDefault();
          var fishFamily = this._dbContext.FishFamilies.Where(f => f.Id == fish.FishFamily.Id).FirstOrDefault();
          var habitat = this._dbContext.Habitats.Where(h => h.Id == fish.Habitat.Id).FirstOrDefault();

            this._dbContext.Add(new Fish()
            {
                Name = fish.Name,
                Description = fish.Description,
                WaterTypeId = waterType.Id,
                WaterType = waterType,
                FishFamily = fishFamily,
                FishFamilyId = fishFamily.Id,
                Habitat = habitat,
                HabitatId = habitat.Id,
                Image = fish.Image,
                MinSchoolSize = fish.MinSchoolSize,
                AvgSchoolSize = fish.AvgSchoolSize,
                MinAquariumSizeInL = fish.MinAquariumSizeInL,
                Gender = fish.Gender,
                MaxNumberOfSameGender = fish.MaxNumberOfSameGender,
                AvailableInStore = fish.AvailableInStore
            });

            this._dbContext.SaveChanges();

            return Ok();
        }

     
        [HttpPut]
        [Route("fish/{id}")]
        public IActionResult Put(int id, [FromBody] FishDTO fish)
        {
            var waterType = this._dbContext.WaterTypes.Where(w => w.Id == fish.WaterType.Id).FirstOrDefault();
            var fishFamily = this._dbContext.FishFamilies.Where(f => f.Id == fish.FishFamily.Id).FirstOrDefault();
            var habitat = this._dbContext.Habitats.Where(h => h.Id == fish.Habitat.Id).FirstOrDefault();

            var fishDB = this._dbContext.Fish.First(f => f.Id == fish.Id);

            fishDB.Name = fish.Name;
            fishDB.Description = fish.Description;
            fishDB.WaterTypeId = fish.WaterType.Id;
            fishDB.WaterType = waterType;
            fishDB.Habitat = habitat;
            fishDB.HabitatId = habitat.Id;
            fishDB.FishFamilyId = fishFamily.Id;
            fishDB.FishFamily = fishFamily;
            fishDB.Image = fish.Image;
            fishDB.MinSchoolSize = fish.MinSchoolSize;
            fishDB.AvgSchoolSize = fish.AvgSchoolSize;
            fishDB.MinAquariumSizeInL = fish.MinAquariumSizeInL;
            fishDB.Gender = fish.Gender;
            fishDB.MaxNumberOfSameGender = fish.MaxNumberOfSameGender;
            fishDB.AvailableInStore = fish.AvailableInStore;

            this._dbContext.SaveChanges();

            return Ok();
        }

        [HttpDelete("fish/{id}")]
        public IActionResult Delete(int id)
        {
            var fish = this._dbContext.Fish.First(p => p.Id == id);
            this._dbContext.Fish.Remove(fish);

            this._dbContext.SaveChanges();

            return Ok();

        }



        public class FishDTO
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }

            public WaterTypeDTO WaterType { get; set; }

            public FishFamilyDTO FishFamily { get; set; }

            public HabitatDTO Habitat { get; set; }

            public string Image { get; set; }

            public int MinSchoolSize { get; set; }

            public int AvgSchoolSize { get; set; }

            public int MinAquariumSizeInL { get; set; }

            public string Gender { get; set; }

            public int MaxNumberOfSameGender { get; set; }

            public int AvailableInStore { get; set; }
        }

        public class WaterTypeDTO
        {
            public int Id { get; set; }

            public string Type { get; set; }
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

        public class HabitatDTO
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
