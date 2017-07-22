using System;

namespace HolidayMangement.Infrastructure.Command
{
    public class CreateEmployee
    {
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
