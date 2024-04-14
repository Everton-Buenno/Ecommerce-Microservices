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
    public class GellAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypesResponse>>
    {


        private readonly ITypeRepository _typeRepository;

        public GellAllTypesHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<IList<TypesResponse>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var typeList = await _typeRepository.GetAllTypes();
            var typesResponse = ProductMapper.Mapper.Map<IList<TypesResponse>>(typeList);
            return typesResponse;
        }
    }
}
