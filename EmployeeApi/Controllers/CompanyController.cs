using EmployeeApi.Dtos;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _companyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompanyCreateDto company)
        {
            await _companyService.CreateAsync(company);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutCompany(CompanyEditDto company)
        {
            await _companyService.UpdateCompanyAsync(company);
            return NoContent();
        }

        [HttpGet]
        [Route("{id}/Employees")]
        public async Task<ActionResult> GetEmployees(int id)
        {
            return Ok(await _companyService.GetEmployeesAsync(id));
        }

        [HttpGet]
        [Route("{id}/EmployeeCount")]
        public async Task<ActionResult> EmployeeCount(int id)
        {
            return Ok(await _companyService.GetEmployeeCountAsync(id));
        }
    }
}
