using HolidayMangement.Infrastructure.Dtos;
using System;
using System.Collections.Generic;

namespace HolidayMangement.Infrastructure.Services.AbstractServices
{
    public interface IEmployeeService
    {
        EmployeeDto GetEmplyee(Guid id);
        EmployeeDto GetEmplyee(string email);
        IEnumerable<EmployeeDto> GetAllEmployees();
        void CreateEmployee(Guid id,string name, string email);
        void UpdateEmployee(Guid id, string name, string email);
        void DeleteEmployee(Guid id);

        void AddVacation(Guid employeeId, DateTime beginDate, DateTime endDate);

    }
}
