﻿using HolidayManagement.Core.Domain;
using HolidayManagement.Core.Repesository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidayMangement.Infrastructure.Repository
{
    public class EmplyeeInMemoryRepository : IEmployeeRepository
    {
        private static readonly ISet<Employee> _employees = new HashSet<Employee>
        {
            new Employee(Guid.NewGuid(), "Borys","Borys@br.pl"),
            new Employee(Guid.NewGuid(), "Witek","Witek@witek.pl"),
            new Employee(Guid.NewGuid(), "Adam", "adam@adam.pl")
        };

        public Employee GetEmployee(Guid Id)
        {
            return _employees.SingleOrDefault(x => x.Id == Id);
        }

        public Employee GetEmployee(string email)
        {
            return _employees.SingleOrDefault(x => x.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees.AsEnumerable();
        }

        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            //save changes
        }

        public void Delete(Employee employee)
        {
            _employees.Remove(employee);}
    }
}
