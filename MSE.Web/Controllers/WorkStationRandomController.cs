using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MSE.DataAccess.Context;
using MSE.DTO.DTOs.WorkStation;
using MSE.Entity.Entities.Concrete;
using System.Net;
using System.Text.Json.Serialization;
using System.Web.Http;
using FromBodyAttribute = System.Web.Http.FromBodyAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace MSE.Web.Controllers
{
    public class WorkStationRandomController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public WorkStationRandomController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] WorkStationRandomValueDTO data)
        {
            if (data != null)
            {
                data.Status = true;
                var workStation = _mapper.Map<WorkStation>(data);
                _dbContext.WorkStations.Add(workStation);
                _dbContext.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("Data cannot be null.");
            }
        }
        [System.Web.Http.HttpGet]
        public string Get()
        {
            return "ok";
        }
    }
}