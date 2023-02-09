using AutoMapper;
using MediatR;
using MSE.Business.Utilities.CustomExceptions;
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
    public class GetProductionLineByIdQuery : IRequest<ProductionLineDTO>
    {
        public int ProductionLineId { get; set; }
        public string ProductionLineName { get; set; }
        public DateTime FirstProductionDate { get; set; }
        public DateTime LastProductionDate { get; set; }

        public class GetProductionLineByIdQueryHandler : IRequestHandler<GetProductionLineByIdQuery, ProductionLineDTO>
        {
            private readonly IProductionLineRepository _productionLineRepository;
            private readonly IMapper _mapper;

            public GetProductionLineByIdQueryHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
            {
                _productionLineRepository = productionLineRepository;
                _mapper = mapper;
            }

            public async Task<ProductionLineDTO> Handle(GetProductionLineByIdQuery request, CancellationToken cancellationToken)
            {
                var productionLine = await _productionLineRepository.Get(request.ProductionLineId);
                if (productionLine == null)
                {
                    throw new NotFoundException(nameof(ProductionLine));
                }

                return _mapper.Map<ProductionLineDTO>(productionLine);
            }
        }
    }
}

