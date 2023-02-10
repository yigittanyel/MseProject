using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;

namespace MSE.Web.Controllers
{
    public class WorkStationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public WorkStationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var workStations = await _dbContext.WorkStations.Include(x => x.ProductionLine)
                                                            .Where(x => x.Status == true)
                                                            .ToListAsync();
            return View(workStations);
        }


        [HttpGet]
        public IActionResult AddNewWorkStation()
        {
            List<SelectListItem> productionLine = (from x in _dbContext.ProductionLines.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.ProductionLineName,
                                                       Value = x.ProductionLineId.ToString()
                                                   }).ToList();

            ViewBag.productionLine = productionLine;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewWorkStation(WorkStation entity)
        {
            entity.Status = true;
            await _dbContext.WorkStations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> GetWorkStationById(int id)
        {
            List<SelectListItem> productionLine = (from x in _dbContext.ProductionLines.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.ProductionLineName,
                                                       Value = x.ProductionLineId.ToString()
                                                   }).ToList();

            ViewBag.productionLine = productionLine;

            var workStation = await _dbContext.WorkStations.FindAsync(id);
            return View("GetWorkStationById", workStation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateWorkStation(WorkStation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SearchByParameter(string search, DateTime? startDate, DateTime? endDate)
        {
            var allValues = await _dbContext.WorkStations.Include(x => x.ProductionLine).Where(x => x.Status == true).ToListAsync();

            if (!string.IsNullOrEmpty(search))
            {
                allValues = allValues.Where(x => x.ProductionLine.ProductionLineName.Contains(search) || x.StationName.Contains(search)).ToList();
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                allValues = allValues.Where(x => x.ProductionLine.FirstProductionDate >= startDate && x.ProductionLine.LastProductionDate <= endDate).ToList();
            }

            return View(allValues);
        }

        public async Task<IActionResult> DeleteWorkStation(int id)
        {
            var deletedWorkStation = await _dbContext.WorkStations.FirstOrDefaultAsync(x => x.WorkStationId == id);
            _dbContext.WorkStations.Remove(deletedWorkStation);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
