using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Attribute : IEntity
    {
        public int AttributeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
