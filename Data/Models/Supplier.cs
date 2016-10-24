using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Data.Models
{
    [Serializable]
    public class Supplier
    {
        [DisplayName("Id")]
        public int SupplierId { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }


        public virtual ICollection<Product> Products { get; set; }
    }
}
