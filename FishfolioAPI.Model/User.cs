﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }    
        public string? Email { get; set; }
        public int UserType { get; set; }

    }
}
