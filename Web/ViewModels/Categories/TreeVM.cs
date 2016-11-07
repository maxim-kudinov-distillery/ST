using Data.Models;
using System.Collections.Generic;

namespace Web.ViewModels.Categories
{
    public class TreeVM
    {
        public IEnumerable<Category> Categories { get; set; }
    }
}