using EmployeePortal.Models;
using EmployeePortal.Reposotory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly EmployeeReposotory emp;
        public EmployeeController(EmployeeReposotory empRepo)
        {
            this.emp = empRepo;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var allEmp = await emp.GetAllEmployee();
            return Ok(allEmp);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee vn)
        {
            await emp.SaveEmployee(vn);
            return Ok(vn);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult>updateEmployee(int id, [FromBody]Employee vm)
        {
            await emp.updateEmploye(id, vm);
            return Ok(vm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteEmployee(int id)
        {
            await emp.DeleteEmployee(id);
            return Ok();
        }

    }
}
