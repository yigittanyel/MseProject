using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MSE.DataAccess.Context;
using MSE.Entity.Entities.Concrete;
using System.Net.Mail;
using System.Net;
using MimeKit;

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
            var alarms = await _dbContext.Alarms.Include(x=>x.WorkStation).ToListAsync();
            return View(alarms);
        }

        [HttpGet]
        public async Task<IActionResult> AddNewAlarm()
        {
            List<SelectListItem> workStation = (from x in _dbContext.WorkStations.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StationName,
                                                    Value = x.WorkStationId.ToString()
                                                }).ToList();

            ViewBag.workStation = workStation;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAlarm(Alarm entity)
        {
                await _dbContext.Alarms.AddAsync(entity);
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
            List<SelectListItem> workStation = (from x in _dbContext.WorkStations.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.StationName,
                                                    Value = x.WorkStationId.ToString()
                                                }).ToList();

            ViewBag.workStation = workStation;

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
