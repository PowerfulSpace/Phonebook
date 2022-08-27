using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Employee> GetAsync(int id) => await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Employee> GetAll() => _dbContext.Employees;


        public async Task<Employee> CreateAsync(Employee entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Employees.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Employee> UpdateAsync(Employee entity)
        {
            if (entity == null) { return null!; }
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Employee> DeletAsync(Employee entity)
        {
            if (entity == null) { return null!; }
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }
    }
}
