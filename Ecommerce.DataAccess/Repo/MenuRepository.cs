using Ecommerce.Data;
using Ecommerce.DataAccess.Repo.IRepo;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repo
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Menu menu)
        {
            var objFromDb = _db.Menus.FirstOrDefault(s => s.Id == menu.Id);

            if(objFromDb != null)
            {
                objFromDb.Name = menu.Name;
            }
        }

        
    }
}
