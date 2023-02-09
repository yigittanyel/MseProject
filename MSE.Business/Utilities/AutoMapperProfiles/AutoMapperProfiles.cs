using AutoMapper;
using MSE.Business.Features.Commands.ProductionLine;
using MSE.DTO.DTOs.Alarm;
using MSE.DTO.DTOs.MaintenancePersonnel;
using MSE.DTO.DTOs.ProductionLine;
using MSE.DTO.DTOs.WorkStation;
using MSE.Entity.Entities.Concrete;

namespace MSE.Business.Utilities.AutoMapperProfiles
{
    public static class AutoMapperProfiles
    {
        public class AutoMapperProfile : Profile
        {
            public AutoMapperProfile()
            {
                CreateMap<Alarm, AlarmDTO>().ReverseMap();
                CreateMap<Alarm, AlarmToAddDTO>().ReverseMap();

                CreateMap<MaintenancePersonnel, MaintenancePersonnelDTO>().ReverseMap();
                CreateMap<MaintenancePersonnel, MaintenancePersonnelToAddDTO>().ReverseMap();

                CreateMap<WorkStation, WorkStationDTO>().ReverseMap();
                CreateMap<WorkStation, WorkStationToAddDTO>().ReverseMap();


                CreateMap<ProductionLine, ProductionLineDTO>().ReverseMap();
                CreateMap<ProductionLine, ProductionLineToAddDTO>().ReverseMap();
                CreateMap<ProductionLine, UpdateProductionLineCommand>().ReverseMap();
                CreateMap<ProductionLine, DeleteProductionLineCommand>().ReverseMap();

            }
        }
    }
}
