using AutoMapper;
using MediatR;
using MSE.DataAccess.Repositories.Abstract;
using MSE.DTO.DTOs.ProductionLine;

namespace MSE.Business.Features.Commands.ProductionLine
{
    public class CreateProductionLineCommand : IRequest<ProductionLineToAddDTO>
    {
        public string ProductionLineName { get; set; }
        public DateTime FirstProductionDate { get; set; }
        public DateTime LastProductionDate { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductionLineCommand, ProductionLineToAddDTO>
        {
            private readonly IProductionLineRepository _productionLineRepository;
            private readonly IMapper _mapper;

            public CreateProductCommandHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
            {
                _productionLineRepository = productionLineRepository;
                _mapper = mapper;
            }

            public async Task<ProductionLineToAddDTO> Handle(CreateProductionLineCommand request, CancellationToken cancellationToken)
            {
                var productionLine = new MSE.Entity.Entities.Concrete.ProductionLine()
                {
                    ProductionLineName = request.ProductionLineName,
                    FirstProductionDate = request.FirstProductionDate,
                    LastProductionDate = request.LastProductionDate
                };

                await _productionLineRepository.Add(productionLine);
                return _mapper.Map<ProductionLineToAddDTO>(productionLine);
            }
        }
    }
}