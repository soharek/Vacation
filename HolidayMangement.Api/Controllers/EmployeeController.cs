using HolidayMangement.Infrastructure.Command;
using HolidayMangement.Infrastructure.Dtos;
using HolidayMangement.Infrastructure.Services.AbstractServices;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HolidayMangement.Api.Controllers
{

    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeServices;

        public EmployeeController(IEmployeeService employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public IEnumerable<EmployeeDto> GetAll()
        {
            return _employeeServices.GetAllEmployees();
        }

        [HttpGet]
        
        public EmployeeDto Get(Guid id)
        {
            return _employeeServices.GetEmplyee(id);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]CreateEmployee command)
        {
            
             command.EmployeeId = Guid.NewGuid();
            _employeeServices.CreateEmployee(command.EmployeeId, command.Name,command.Email);

            return Ok();
        }


        [HttpPut]
        public IHttpActionResult Update(Guid id, [FromBody] UpdateEmployee command)
        {
            _employeeServices.UpdateEmployee(id,command.Name, command.Email);

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddVacation(Guid id, [FromBody] SetVacation command)
        {
             _employeeServices.AddVacation(id, command.BeginDate, command.EndDate);

            return Ok();
        }


    }
}
