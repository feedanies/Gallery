using Lesson5.Domain.Abstract;
using Lesson5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace Lesson5.DataAccess
{
    public class SaleRepository : IRepository<Sale>
    {
        private readonly GalleryContext _context;

        public SaleRepository(GalleryContext context)
        {
            _context = context;
        }

        public Sale? Add(Sale obj)
        {
            return _context.Sales.Add(obj).Entity;
        }

        public bool Delete(Sale obj)
        {
            return _context.Sales.Remove(obj) != null;
        }

        public Sale? Get(Expression<Func<Sale, bool>> exp)
        {
            return _context.Sales.FirstOrDefault(exp);
        }

        public Sale? Get(int id)
        {
            return _context.Sales.SingleOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sale> GetAll(Expression<Func<Sale, bool>> exp)
        {
            return exp != null ? _context.Sales.Where(exp) : _context.Sales;
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Sale? Update(Sale obj)
        {
            return _context.Sales.Update(obj).Entity;
        }
    }
}
