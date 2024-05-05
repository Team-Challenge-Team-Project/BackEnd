using AutoMapper;
using Catalog.BLL.Interfaces;

namespace Catalog.BLL;

public class ProductsProvider : IProductsProvider
{
    private readonly IMapper _mapper;
        
    public ProductsProvider(IMapper mapper)
    {
        _mapper = mapper;
    }
}