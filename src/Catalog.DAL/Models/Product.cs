using Catalog.DAL.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public bool IsDeleted { get; set; }
        public string MaterialAndFit {  get; set; }
        public int Discount { get; set; }
        public ProductSex Sex { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductVariant> ProductVariants { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
