﻿using Data.Models;
using System.Collections.Generic;

namespace Web.ViewModels.Categories
{
    public class CategoriesVM: TreeVM
    {
        public Category Category { get; set; }
    }
}