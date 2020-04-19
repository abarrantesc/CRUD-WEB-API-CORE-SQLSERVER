using System;
using System.Collections.Generic;
using System.Linq;
using API_REST.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API_REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployees _employeesI;

        public EmployeeController(IEmployees _employees)
        {
            _employeesI = _employees;
        }

        [HttpGet]
        public ActionResult<EmplyeesModel> GetAll()
        {
            try
            {
                var result = _employeesI.GetListEmployee();

                if (!result.Any())
                {
                    return StatusCode(200, "Employee not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Error Server" + ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<EmplyeesModel> GetEmployeeID(int id)
        {
            try
            {
                var result = _employeesI.GetEmployeeID(id);

                if (!result.Any())
                {
                    return StatusCode(200, "Employee not found with id:" + id);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "Internal Error Server" + ex);
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(EmplyeesModel employee)
        {
            try
            {
                var result = _employeesI.AddEmployee(employee);

                if (result == "0")
                {
                    return Ok(new { message = "Employee Deleted Successfully", code = 0 });
                }
                else
                {
                    return BadRequest(new { message = "Employee Not Delete Successfully", code = 0 });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Error Server", ErrorMessage = "" + ex });
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, EmplyeesModel employee)
        {
            try
            {
                var result = _employeesI.UpdateEmployee(id, employee);
                if (result == "0")
                {
                    return Ok(new { message = "Employee Deleted Successfully", code = 0 });
                }
                else
                {
                    return BadRequest(new { message = "Employee Not Delete Successfully", code = 0 });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Error Server", ErrorMessage = "" + ex });
            }

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                var result = _employeesI.DeleteEmployee(id);
                if (result == "0")
                {
                    return Ok(new { message = "Employee Deleted Successfully",code=0 });
                }
                else
                {
                    return BadRequest(new { message = "Employee Not Delete Successfully", code = 0 });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Internal Error Server", ErrorMessage = "" + ex });
            }

        }

    }



}
