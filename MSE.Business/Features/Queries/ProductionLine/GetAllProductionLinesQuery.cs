using AutoMapper;
using MediatR;
using MSE.DataAccess.Repositories.Abstract;
using MSE.DTO.DTOs.ProductionLine;
using MSE.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Business.Features.Queries.ProductionLine
{
    public class GetAllProductionLinesQuery : IRequest<List<ProductionLineDTO>>
    {
        public class GetAllProductionLinesQueryHandler : IRequestHandler<GetAllProductionLinesQuery, List<ProductionLineDTO>>
        {
            private readonly IProductionLineRepository _productionLineRepository;
            private readonly IMapper _mapper;

            public GetAllProductionLinesQueryHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
            {
                _productionLineRepository = productionLineRepository;
                _mapper = mapper;
            }

            public async Task<List<ProductionLineDTO>> Handle(GetAllProductionLinesQuery request, CancellationToken cancellationToken)
            {
                var productionLines = await _productionLineRepository.GetList();
                return _mapper.Map<List<ProductionLineDTO>>(productionLines);
            }
        }
    }
}
