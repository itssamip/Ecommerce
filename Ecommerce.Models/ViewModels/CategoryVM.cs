using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public IEnumerable<SelectListItem> MenuList { get; set; }

    }
}
