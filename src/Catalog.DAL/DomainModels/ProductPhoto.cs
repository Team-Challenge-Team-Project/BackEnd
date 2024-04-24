using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.DomainModels
{
    public class ProductPhoto
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
