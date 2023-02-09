using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;

namespace MSE.Web.Controllers
{
    public class PersonnelController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonnelController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var personnels = await _dbContext.MaintenancePersonnels.ToListAsync();
            return View(personnels);
        }

        [HttpGet]
        public IActionResult AddNewPersonnel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewPersonnel(MaintenancePersonnel entity)
        {
            await _dbContext.MaintenancePersonnels.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetPersonnelById(int id)
        {
            var personnel = await _dbContext.MaintenancePersonnels.FindAsync(id);
            return View("GetPersonnelById", personnel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonnel(MaintenancePersonnel entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePersonnel(int id)
        {
            var deletedPersonnel = _dbContext.MaintenancePersonnels.FirstOrDefault(x => x.MaintenancePersonnelId == id);
            _dbContext.MaintenancePersonnels.Remove(deletedPersonnel);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
