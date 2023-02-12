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

        //Mevcut var olan tüm alarmları listeler.
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

        //Yeni bir alarm oluşturulur. Work station bilgileri dropdown list olarak getirilir.
        [HttpPost]
        public async Task<IActionResult> AddNewAlarm(Alarm entity)
        {
                await _dbContext.Alarms.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
        }

        // Alarmı veritabanından silmek istersek çalıştırılacak endpoint.
        public async Task<IActionResult> DeleteAlarm(int id)
        {
            var deletedAlarm = _dbContext.Alarms.FirstOrDefault(x => x.AlarmId == id);
            _dbContext.Alarms.Remove(deletedAlarm);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //İlgili alarmın detaylarının görüntüleneceği endpoint.
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

        //Alarmı update etmek istersek çalışacak endpoint.
        [HttpPost]
        public async Task<IActionResult> UpdateAlarm(Alarm entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SendEmail(int id)
        {
            var personnel=await _dbContext.WorkStationPersonnels.Where(x=>x.WorkStationId==id).Select(x=>x.MaintenancePersonnel.EmailAdress).ToListAsync();
            foreach(var x in personnel)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("tanyelyigit@gmail.com");
                message.To.Add(x);
                message.Subject = "Important Notification";
                message.Body = "There is an error!";

                SmtpClient smtp = new SmtpClient();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("tanyelyigit@gmail.com", "my-password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }

            return RedirectToAction("Index");
        }

    }
}
