using HolidayManagement.Core.Domain;
using System;
using System.Collections.Generic;

namespace HolidayManagment.Repository.Repositories.AbstractRepositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(Guid Id);
        Employee GetEmployee(string email);
        IEnumerable<Employee> GetAllEmployees();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
    }
}
