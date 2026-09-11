using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string? Color { get; set; }
        public bool IsNew { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public Car()
        {
            Sales = new List<Sale>();
        }
    }
}
