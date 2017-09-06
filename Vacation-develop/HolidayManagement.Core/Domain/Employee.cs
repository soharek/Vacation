using System;
using System.Collections.Generic;

namespace HolidayManagement.Core.Domain
{
    public class Employee
    {
        private ISet<Vacation> _vacations = new HashSet<Vacation>();
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Email { get;protected set; }
        public int VacationDays { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime EmploymentStart { get; set; }
        public IEnumerable<Vacation> Vacations => _vacations;

        protected Employee()
        {
            
        }

        public Employee (Guid id,string name,string email)
        {
            Id = id;
            SetName(name);
            SetEmail(email);
            EmploymentStart =DateTime.UtcNow;
            VacationDays = 26;
            IsDeleted = false;

        }

        public void Delete()
        {
            IsDeleted = true;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty or white space");
            }

            Name = name;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email cannot be empty or white space");
            }

            if (!email.Contains("@"))
            {
                throw new Exception("Email must be in proper format");
            }

            Email = email;
        }


        public void AddVacation(DateTime beginDate, DateTime endDate)
        {
            if (beginDate > endDate)
            {
                throw new Exception("Begin date cannot be grater than end date");
            }

            var numberofDays = (int) (endDate - beginDate).TotalDays;
            if ( numberofDays> VacationDays)
            {
                throw new Exception("Not enaugh vacation days");
            }

            _vacations.Add(new Vacation(this.Id, beginDate, endDate));
            VacationDays -= numberofDays;


        }





    }
}
