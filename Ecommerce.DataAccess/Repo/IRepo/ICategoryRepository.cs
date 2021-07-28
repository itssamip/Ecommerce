﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repo.IRepo
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
