using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.Model
{
    public class Fish
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
        
        [ForeignKey(nameof(WaterType))]
        public int WaterTypeId { get; set; }

        public WaterType? WaterType { get; set; }

        [ForeignKey(nameof(FishFamily))]
        public int FishFamilyId { get; set; }

        public FishFamily? FishFamily { get; set; }

        [ForeignKey(nameof(Habitat))]
        public int HabitatId { get; set; }

        public Habitat? Habitat { get; set; }

        public string Image { get; set; }

        public int MinSchoolSize { get; set; }
        
        public int AvgSchoolSize { get; set; }

        public int MinAquariumSizeInL { get; set; }

        public string Gender { get; set; }

        public int MaxNumberOfSameGender { get; set; }

        public int AvailableInStore { get; set; }
    }
}
