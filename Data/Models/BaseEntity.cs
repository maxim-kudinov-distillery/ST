using System;
using System.ComponentModel;

namespace Data.Models
{
    public abstract class BaseEntity
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
