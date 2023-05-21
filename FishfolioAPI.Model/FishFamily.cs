using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.Model
{
    public class FishFamily
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FishFamilyCompatibility>? CompatibleWith { get; set; }     

        public virtual ICollection<FishFamilyIncompatibility>? IncompatibleWith { get; set; }

        public virtual ICollection<Fish>? Fish { get; set; }
    }

    public class FishFamilyCompatibility
    {
        public int ParentId { get; set; }
        public int CompatibilityId { get; set; }

        public virtual FishFamily? Compatible { get; set; }
        public virtual FishFamily? Parent { get; set; }
    }

    public class FishFamilyIncompatibility
    {
        public int ParentId { get; set; }
        public int CompatibilityId { get; set; }

        public virtual FishFamily? Incompatible { get; set; }
        public virtual FishFamily? Parent { get; set; }
    }

}
