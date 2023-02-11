using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;
using System.Net.Mail;
using System.Net;

namespace MSE.Web.Controllers
{
    public class WorkStationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public WorkStationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //Statusu aktif olan iş istasyonlarını listeler.
        public async Task<IActionResult> Index()
        {
            var workStations = await _dbContext.WorkStations.Include(x => x.ProductionLine)
                                                            .Where(x => x.Status == true)
                                                            .ToListAsync();
            return View(workStations);
        }


        // İlgili iş istasyonunun bilgilerinin getirildiği yapımız.
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

        //İş istasyonundaki değerleri güncellediğimiz endpoint.
        [HttpPost]
        public async Task<IActionResult> UpdateWorkStation(WorkStation entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //İş istasyonundaki veriyi silmemizi sağlayan kod. Burada statusu false'a çekerek de işlem yapabilirdik. Fakat onu güncelleme
        //kısmında kullandım. Burada veritabanından silmek istediğimizde çalıştıracağımız kod var.
        public async Task<IActionResult> DeleteWorkStation(int id)
        {
            var deletedWorkStation = await _dbContext.WorkStations.FirstOrDefaultAsync(x => x.WorkStationId == id);
            _dbContext.WorkStations.Remove(deletedWorkStation);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Üretim hatlarına, iş istasyonuna ve tarih aralığına göre sorgulama yapabileceğimiz endpoint.
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

        //Yeni iş istasyonu eklemek için gerekli endpointler.
        [HttpGet]
        public IActionResult AddWorkStation()
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
        public async Task<IActionResult> AddWorkStation(WorkStation entity)
        {
            entity.Status = true;
            await _dbContext.WorkStations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }
}
