using Lesson5.Domain.Abstract;
using Lesson5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace Lesson5.DataAccess
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly GalleryContext _context;

        public CustomerRepository(GalleryContext context)
        {
            _context = context;
        }

        public Customer? Add(Customer obj)
        {
            return _context.Customers.Add(obj).Entity;
        }

        public bool Delete(Customer obj)
        {
            return _context.Customers.Remove(obj) != null;
        }

        public Customer? Get(Expression<Func<Customer, bool>> exp)
        {
            return _context.Customers.FirstOrDefault(exp);
        }

        public Customer? Get(int id)
        {
            return _context.Customers.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> exp)
        {
            return exp != null ? _context.Customers.Where(exp) : _context.Customers;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Customer? Update(Customer obj)
        {
            return _context.Customers.Update(obj).Entity;
        }
    }
}
