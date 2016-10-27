﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Serializable]
    public class Category: BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }

        [ForeignKey("ParentId")]
        public virtual ICollection<Category> Children { get; set; }
    }
}