using Lesson5.Domain.Abstract;
using Lesson5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lesson5.DataAccess
{
    public class CarRepository : ICarRepository
    {
        private readonly GalleryContext _context;

        public CarRepository(GalleryContext context)
        {
            _context = context;
        }
        public Car? Add(Car obj)
        {
            return _context.Cars.Add(obj).Entity;
        }

        public bool Delete(Car obj)
        {
            return _context.Cars.Remove(obj) != null;
        }

        public Car? Get(int id)
        {
            return _context.Cars.SingleOrDefault(c => c.Id == id);
        }

        public IQueryable<Car> GetAll()
        {
            return _context.Cars;
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public Car? Update(Car obj)
        {
            return _context.Cars.Update(obj).Entity;
        }
    }
}
