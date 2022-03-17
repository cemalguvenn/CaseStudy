using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{

    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

    }
}
