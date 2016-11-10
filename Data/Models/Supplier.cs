using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    [Serializable]
    public class Supplier
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
