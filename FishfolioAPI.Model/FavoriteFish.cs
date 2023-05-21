using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.Model
{
    public class FavoriteFish
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey (nameof(Fish))]
        public int FishId { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual Fish? Fish { get; set; }
        public virtual User? User { get; set; }
    }
}
