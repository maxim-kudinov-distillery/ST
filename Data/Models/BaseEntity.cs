using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public abstract class BaseEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
