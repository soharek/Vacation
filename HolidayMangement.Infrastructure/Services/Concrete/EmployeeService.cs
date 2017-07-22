using AutoMapper;
using HolidayManagement.Core.Domain;
using HolidayManagement.Core.Repesository;
using HolidayMangement.Infrastructure.Dtos;
using HolidayMangement.Infrastructure.Services.AbstractServices;
using System;
using System.Collections.Generic;

namespace HolidayMangement.Infrastructure.Services.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public EmployeeDto GetEmplyee(Guid id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public EmployeeDto GetEmplyee(string email)
        {
            var employee = _employeeRepository.GetEmployee(email);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public void CreateEmployee(Guid id,string name, string email)
        {
            var employee = _employeeRepository.GetEmployee(email);
            if (employee != null)
            {
                throw new Exception("Employee already exists");
            }

            employee = new Employee(id, name, email);

            _employeeRepository.Add(employee);

        }

        
        public void UpdateEmployee(Guid id,string name, string email)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            employee.SetName(name);
            employee.SetEmail(email);

        }

        public void DeleteEmployee(Guid id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            _employeeRepository.Delete(employee);
        }

        public void AddVacation(Guid employeeId, DateTime beginDate, DateTime endDate)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            if (employee == null)
            {
                throw new Exception("Employee does not exist");
            }

            employee.AddVacation(beginDate,endDate);

            _employeeRepository.Update(employee);

            
        }
    }
}
