using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using PS.Phonebook.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class EmployeesPhonebookRepository : IEmployeesPhonebook
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeesPhonebookRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<EmployeesPhonebook> GetAsync(int id) => await _dbContext.EmployeesPhonebooks.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<EmployeesPhonebook> GetAll() => _dbContext.EmployeesPhonebooks;


        public IQueryable<EmployeesPhonebook> GetAll(string propertyName, SortOrder sortOrder) => _dbContext.EmployeesPhonebooks;
        public IQueryable<EmployeesPhonebook> GetAll(string propertyName, SortOrder sortOrder, string searchText)
        {
            IQueryable<EmployeesPhonebook> employeesPhonebooks;

            if (searchText != "" && searchText != null)
            {
                employeesPhonebooks = _dbContext.EmployeesPhonebooks.
                    Where(x => x.Employee.FirstName.Contains(searchText) 
                    || x.Employee.Organization.Name.Contains(searchText));
            }
            else
            {
                employeesPhonebooks = _dbContext.EmployeesPhonebooks;
            }

            return employeesPhonebooks;
        }



        public async Task<EmployeesPhonebook> CreateAsync(EmployeesPhonebook entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.EmployeesPhonebooks.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<EmployeesPhonebook> UpdateAsync(EmployeesPhonebook entity)
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

        public async Task<EmployeesPhonebook> DeletAsync(EmployeesPhonebook entity)
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
