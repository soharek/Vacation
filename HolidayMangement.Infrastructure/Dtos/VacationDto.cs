using System;

namespace HolidayMangement.Infrastructure.Dtos
{
    public class VacationDto
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Length { get; set; }
    }
}