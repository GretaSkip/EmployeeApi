using EmployeeApi.Data;
using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class CompanyRepository
    {
        private readonly DataContext _context;

        public CompanyRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAsync()
        {
            return await _context.Companies.Include(p => p.Employees).ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _context.Companies.Include(pa => pa.Employees).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreateAsync(Company company)
        {
            _context.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeesAsync(int companyId)
        {
            return await _context.Employees.Where(x => x.CompanyId == companyId).ToListAsync();
        }


    }
}
