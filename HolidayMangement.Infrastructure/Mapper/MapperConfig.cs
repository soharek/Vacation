using AutoMapper;
using HolidayManagement.Core.Domain;
using HolidayMangement.Infrastructure.Dtos;

namespace HolidayMangement.Infrastructure.Mapper
{
    public static class MapperConfig
    {
        public static IMapper Configure()
            =>new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
                cfg.CreateMap<Employee, EmployeeDetailsDto>();
                cfg.CreateMap<Vacation, VacationDto>();
            }).CreateMapper();
    }
}
