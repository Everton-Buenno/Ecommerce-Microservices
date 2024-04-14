using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers
{
    public class GetProductsByBrandHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductsByBrandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            var productsByBrandList = await _productRepository.GetProductByBrand(request.Brand);
            var productsByBrandResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(productsByBrandList);
            return productsByBrandResponse;
        }
    }
}
