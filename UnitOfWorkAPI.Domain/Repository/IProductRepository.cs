using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAPI.Domain.Entities;

namespace UnitOfWorkAPI.Domain.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
