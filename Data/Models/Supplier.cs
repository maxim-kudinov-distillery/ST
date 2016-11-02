using System;
using System.Collections.Generic;

namespace Data.Models
{
    [Serializable]
    public class Supplier: BaseEntity
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
