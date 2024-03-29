﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Display(Name ="Menu Names")]
        [Required]
        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
