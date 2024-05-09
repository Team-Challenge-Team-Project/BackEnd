using AutoMapper;
using Catalog.BLL.Interfaces;

namespace Catalog.BLL
{
    public class ProductsCreator : IProductsCreator
    {
        private readonly IMapper _mapper;
        
        public ProductsCreator(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
