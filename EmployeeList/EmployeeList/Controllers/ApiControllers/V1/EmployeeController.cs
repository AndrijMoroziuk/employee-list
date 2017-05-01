using EmployeeList.Domain.Entities.Models;
using EmployeeList.Services.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EmployeeList.Web.Controllers.ApiControllers.V1
{
    [Authorize]
    [RoutePrefix("api")]
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [Route("employeelist")]
        public async Task<IHttpActionResult> Get(int skip = 0, int take = int.MaxValue)
        {
            var myId = User.Identity.GetUserId();
            var result = await _employeeService.GetListAsync(myId, skip, take);

            return Ok(result);
        }
        
        [HttpPost]
        [Route("employee")]
        public async Task<IHttpActionResult> Create(Employee employee)
        {
            var myId = User.Identity.GetUserId();
            var result = await _employeeService.CreateAsync(employee, myId);

            return Ok(result);
        }
        
        [HttpDelete]
        [Route("employee")]
        public async Task<IHttpActionResult> Delete(string id)
        {
            var myId = User.Identity.GetUserId();
            var result = await _employeeService.DeleteAsync(id, myId);

            return Ok(result);
        }
    }
}
