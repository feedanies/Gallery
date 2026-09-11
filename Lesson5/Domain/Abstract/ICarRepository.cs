using Lesson5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Abstract
{
    public interface ICarRepository
    {
        Car? Get(int id);
        IQueryable<Car> GetAll();
        Car? Add(Car obj);
        Car? Update(Car obj);
        bool Delete(Car obj);
        bool SaveChanges();
    }
}
