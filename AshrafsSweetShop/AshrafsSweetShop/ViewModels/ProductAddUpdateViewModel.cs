using AshrafsSweetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AshrafsSweetShop.ViewModels
{
    public class ProductAddUpdateViewModel
    {
        public string Action { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}
