using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.Domain.Entities;
using UnitOfWorkAPI.Domain.Repository;

namespace UnitOfWorkAPI.DataAccess.Implementation
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        public BrandRepository(UowDbContext context) : base(context)
        {
        }
    }
}
