﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ProductCategory : IEntity
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<Attribute> Attributes { get; set; }
    }
}
