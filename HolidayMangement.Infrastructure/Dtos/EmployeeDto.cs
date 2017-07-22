using System;

namespace HolidayMangement.Infrastructure.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public string Email { get; set; }
        public int VacationDays { get; protected set; }
    }
}
