using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.Model
{
    public class WaterType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Fish>? Fish { get; set; }
    }
}
