using MediatR;
using Microsoft.AspNetCore.Mvc;
using MSE.Business.Features.Commands.ProductionLine;
using MSE.Business.Features.Queries.ProductionLine;
using MSE.DTO.DTOs.ProductionLine;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MSE.Web.Controllers
{
    public class ProductionLineController : Controller
    {
        private readonly IMediator _mediator;

        public ProductionLineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllProductionLinesQuery();
            return View(await _mediator.Send(query));
        }

        public async Task<IActionResult> GetProductionLineById(int id)
        {
            var result = await _mediator.Send(new GetProductionLineByIdQuery { ProductionLineId = id });
            return View("GetProductionLineById", result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductionLine(UpdateProductionLineCommand entity)
        {
            var request = new UpdateProductionLineCommand { ProductionLineId = entity.ProductionLineId, ProductionLineName = entity.ProductionLineName, FirstProductionDate = entity.FirstProductionDate, LastProductionDate = entity.LastProductionDate };
            var updatedEntity = await _mediator.Send(request);
            return RedirectToAction("Index",updatedEntity);
        }

        public async Task<IActionResult> DeleteProductionLine(int id)
        {
            var request = new DeleteProductionLineCommand { Id = id };
            await _mediator.Send(request);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> AddNewProductionLine()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProductionLine(ProductionLineToAddDTO entity)
        {
            var request = new CreateProductionLineCommand { ProductionLineName=entity.ProductionLineName,FirstProductionDate=entity.FirstProductionDate,LastProductionDate=entity.LastProductionDate };
            var addedEntity = await _mediator.Send(request);
            return RedirectToAction("Index", addedEntity);
        }
    }
}
