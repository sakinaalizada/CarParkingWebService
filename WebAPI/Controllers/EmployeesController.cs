using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
            private IEmployeeService _employeeService;
            public EmployeesController(IEmployeeService employeeService)
            {
                _employeeService = employeeService;
            }
            [HttpPost]
            public IActionResult Add(Employee employee)
            {
                var result = this._employeeService.Add(employee);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            [HttpPut]
            public IActionResult Update(Employee employee)
            {
                var result = this._employeeService.Update(employee);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            [HttpDelete]
            public IActionResult Delete(Employee employee)
            {
                var result = this._employeeService.Delete(employee);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            [HttpGet]
            public IActionResult GetAll()
            {
                var result = this._employeeService.GetAll();
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);

            }
            [HttpGet("getbyid")]
            public IActionResult GetById(int id)
            {
                var result = this._employeeService.GetById(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);

            }
        
    }
}
