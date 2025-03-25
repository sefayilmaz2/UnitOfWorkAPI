using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWorkAPI.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Product { get; }
        IBrandRepository Brand { get; }
        int Save();
    }

}
