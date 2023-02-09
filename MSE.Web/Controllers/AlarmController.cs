using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;

namespace MSE.Web.Controllers
{
    public class AlarmController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AlarmController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var alarms = await _dbContext.Alarms.ToListAsync();
            return View(alarms);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewAlarm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAlarm(Alarm entity)
        {
            var alarm = await _dbContext.Alarms.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAlarm(int id)
        {
            var deletedAlarm = _dbContext.Alarms.FirstOrDefault(x => x.AlarmId == id);
            _dbContext.Alarms.Remove(deletedAlarm);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetAlarmById(int id)
        {
            var alarm = await _dbContext.Alarms.FindAsync(id);
            return View("GetAlarmById", alarm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAlarm(Alarm entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
