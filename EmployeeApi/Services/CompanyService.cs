using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(CompanyCreateDto company)
        {

            var newCompany = new Company()
            {
                Name = company.Name
            };
            await _companyRepository.CreateAsync(newCompany);
        }

        public async Task DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(company);
        }

        public async Task UpdateCompanyAsync(CompanyEditDto company)
        {
            var existingCompany = await GetByIdAsync(company.Id);
            existingCompany.Id = company.Id;
            existingCompany.Name = company.Name;
            await _companyRepository.UpdateAsync(existingCompany);
        }

        public async Task<List<Employee>> GetEmployeesAsync(int companyId)
        {
            return await _companyRepository.GetEmployeesAsync(companyId);
        }

        public async Task<int> GetEmployeeCountAsync(int companyId)
        {
            List<Employee> employees = await _companyRepository.GetEmployeesAsync(companyId);
            return employees.Count;
        }
    }
}


