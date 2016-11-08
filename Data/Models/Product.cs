using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Serializable]
    public class Product: BaseEntity
    {
        [DisplayName("Supplier")]
        [Required]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
