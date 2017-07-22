using System.Collections.Generic;

namespace HolidayMangement.Infrastructure.Dtos
{
    public class EmployeeDetailsDto : EmployeeDto
    {
        public IEnumerable<VacationDto> Vacations { get; set; }
    }
}
