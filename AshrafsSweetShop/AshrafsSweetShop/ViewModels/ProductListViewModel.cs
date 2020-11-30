using AshrafsSweetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsSweetShop.ViewModels
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string CheckActiveCategory(string category) => category == SelectedCategory ? "active" : "";
    }
}
