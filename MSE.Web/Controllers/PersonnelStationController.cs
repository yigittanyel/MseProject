using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;

namespace MSE.Web.Controllers
{
    public class PersonnelStationController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonnelStationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Sorumlu personel ve onun bakımından sorumlu olduğu iş istasyonları listelenir.
        public async Task<IActionResult> Index()
        {
            var value = await _dbContext.WorkStationPersonnels
                .Include(x=>x.MaintenancePersonnel)
                .Include(x=>x.WorkStation)
                .ToListAsync();

            return View(value);
        }

        [HttpGet]
        public IActionResult AddNew()
        {
            List<SelectListItem> workStation = (from x in _dbContext.WorkStations.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.StationName,
                                                       Value = x.WorkStationId.ToString()
                                                   }).ToList();

            ViewBag.workStation = workStation;

            List<SelectListItem> personnel = (from x in _dbContext.MaintenancePersonnels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Name+" "+x.Surname,
                                                    Value = x.MaintenancePersonnelId.ToString()
                                                }).ToList();

            ViewBag.personnel = personnel;

            return View();
        }

        //Yeni bir değer post edilmek istendiğinde çalışacak endpoint.

        [HttpPost]
        public async Task<IActionResult> AddNew(WorkStationPersonnel entity)
        {
            await _dbContext.WorkStationPersonnels.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //İlgili kaydı veritabanından silmek istediğimizde çalışacak endpoint.
        public async Task<IActionResult> Delete(int id)
        {
            var deletedItem = await _dbContext.WorkStationPersonnels.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.WorkStationPersonnels.Remove(deletedItem);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //İlgili kayda ait bilgilerin getirileceği endpoint.
        public async Task<IActionResult> GetById(int id)
        {
            List<SelectListItem> workStation = (from x in _dbContext.WorkStations.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StationName,
                                                    Value = x.WorkStationId.ToString()
                                                }).ToList();

            ViewBag.workStation = workStation;

            List<SelectListItem> personnel = (from x in _dbContext.MaintenancePersonnels.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name + " " + x.Surname,
                                                  Value = x.MaintenancePersonnelId.ToString()
                                              }).ToList();

            ViewBag.personnel = personnel;

            var item = await _dbContext.WorkStationPersonnels.FindAsync(id);
            return View("GetById", item);
        }

        //Verilerimizi güncellemek için gerekli endpoint.
        [HttpPost]
        public async Task<IActionResult> Update(WorkStationPersonnel entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
