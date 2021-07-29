using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Menu Type")]
        public int  MenuId { get; set; }
        public Menu Menu { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
