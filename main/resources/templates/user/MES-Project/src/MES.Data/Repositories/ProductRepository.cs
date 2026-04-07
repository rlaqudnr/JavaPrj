using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MES.Core.Interfaces;
using MES.Data.Entities;

namespace MES.Data.Repositories
{
    public class ProductRepository : IRepository<ProductEntity>
    {
        private readonly MESDbContext _context;

        public ProductRepository(MESDbContext context)
        {
            _context = context;
        }

        public void Add(ProductEntity entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Update(ProductEntity entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Products.Find(id);
            if (entity != null)
            {
                _context.Products.Remove(entity);
                _context.SaveChanges();
            }
        }

        public ProductEntity GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            return _context.Products.ToList();
        }
    }
}