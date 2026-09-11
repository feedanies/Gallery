using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string? Fullname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
        public Customer()
        {
            Sales = new List<Sale>();
        }
    }
}
