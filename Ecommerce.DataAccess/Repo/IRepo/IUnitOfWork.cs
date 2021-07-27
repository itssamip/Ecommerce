using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repo.IRepo
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuRepository Menu { get; }

        void Save();
    }
}
