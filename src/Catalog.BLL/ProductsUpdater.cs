using AutoMapper;
using Catalog.BLL.Interfaces;

namespace Catalog.BLL;

public class ProductsUpdater : IProductsUpdater
{
    private readonly IMapper _mapper;
        
    public ProductsUpdater(IMapper mapper)
    {
        _mapper = mapper;
    }
}