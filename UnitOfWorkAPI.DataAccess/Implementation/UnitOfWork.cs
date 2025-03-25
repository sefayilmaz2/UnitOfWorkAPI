using UnitOfWorkAPI.DataAccess.Context;
using UnitOfWorkAPI.Domain.Entities;
using UnitOfWorkAPI.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWorkAPI.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UowDbContext _context;
        
        public UnitOfWork(UowDbContext context)
        {
            _context = context;
            Product = new ProductRepository(_context);
            Brand = new BrandRepository(_context);
        }
        public IProductRepository Product { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
