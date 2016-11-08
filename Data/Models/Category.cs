using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Serializable]
    public class Category: BaseEntity, ITreeRenderable<Category>
    {
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<Category> Children { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
