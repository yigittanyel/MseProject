using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MSE.DataAccess.Context;
using MSE.DTO.DTOs.WorkStation;
using MSE.Entity.Entities.Concrete;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;

namespace MSE.Web.Controllers
{
    public class WorkStationRandomController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkStationRandomController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Console uygulamasından gelen datayı alarak veritabanına post eden endpoint
        [HttpPost]
        public IActionResult Post([FromBody] WorkStationRandomValueDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var workStation = _mapper.Map<WorkStation>(data);
             _dbContext.WorkStations.Add(workStation);
            _dbContext.SaveChanges();

            return Ok();

        }
        //server'a get isteği geldiğinde çalışıyor mu diye kontrol amaçlı oluşturulan endpoint.
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}