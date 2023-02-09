using AutoMapper;
using MediatR;
using MSE.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSE.Business.Features.Commands.ProductionLine
{
    public class UpdateProductionLineCommand : IRequest<bool>
    {
        public int ProductionLineId { get; set; }
        public string ProductionLineName { get; set; }
        public DateTime FirstProductionDate { get; set; }
        public DateTime LastProductionDate { get; set; }

        public class UpdateProductionLineCommandHandler : IRequestHandler<UpdateProductionLineCommand, bool>
        {
            private readonly IProductionLineRepository _productionLineRepository;
            private readonly IMapper _mapper;

            public UpdateProductionLineCommandHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
            {
                _productionLineRepository = productionLineRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(UpdateProductionLineCommand request, CancellationToken cancellationToken)
            {
                var product = await _productionLineRepository.Get(request.ProductionLineId);
                if (product == null)
                    return false;

                _mapper.Map(request, product);

                await _productionLineRepository.Update(product);

                return true;
            }
        }
    }
}
