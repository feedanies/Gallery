using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal SalePrice { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
