using System;

namespace HolidayManagement.Core.Domain
{
    public class Vacation
    {
        public Guid Id { get; set; }
        public Guid EmplyeeId { get;protected set; }
        public DateTime BeginDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public int Length => (int) (EndDate - BeginDate).TotalDays;

        private Vacation()
        {
            
        }

        public Vacation(Guid employeeId,DateTime beginDate, DateTime endDate)
        {
            Id = Guid.NewGuid();
            EmplyeeId = employeeId;
            BeginDate = beginDate;
            EndDate = endDate;
        }



    }
}