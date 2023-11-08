using Microsoft.AspNetCore.Mvc;
using MyrtexTask.Application.Interfaces;
using MyrtexTask.Domain;

namespace MyrtexTask.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            List<Employee> employees = await employeeRepository.GetAllAsync();

            return employees;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            await employeeRepository.CreateAsync(employee);

            return Ok(employee);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            await employeeRepository.UpdateAsync(employee);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await employeeRepository.DeleteAsync(id);

            return Ok();
        }

    }
}