using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Models.ViewModel
{
    public class ProductDetailViewModel
    {
        public List<ProductCategorySale>? ProductCategorySale { get; set; }
        public List<ProductCategorySale>? ProductSale { get; set; }
        public ProductDetailViewModel()
        {
            ProductCategorySale = new List<ProductCategorySale>();
            ProductSale = new List<ProductCategorySale>();
        }
    }

    public class ProductCategorySale
    {
        public string? ProductCategory { get; set; }
        public Int64? totalSale { get; set; }
        public Int64? maxSale { get; set; }
        public Int64? minSale { get; set; }
        public Int64? avgSale { get; set; }
    }

    
}