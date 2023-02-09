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
    public class DeleteProductionLineCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteProductionLineCommandHandler : IRequestHandler<DeleteProductionLineCommand, bool>
        {
            private readonly IProductionLineRepository _productionLineRepository;
            private readonly IMapper _mapper;

            public DeleteProductionLineCommandHandler(IProductionLineRepository productionLineRepository, IMapper mapper)
            {
                _productionLineRepository = productionLineRepository;
                _mapper = mapper;
            }

            public async Task<bool> Handle(DeleteProductionLineCommand request, CancellationToken cancellationToken)
            {
                var productionLine = await _productionLineRepository.Get(request.Id);
                if (productionLine == null)
                    return false;

                await _productionLineRepository.Delete(productionLine);
                return true;
            }
        }
    }
}