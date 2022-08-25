using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class DepartmentReposotiry : IDepartment
    {
        private readonly ApplicationDbContext _dbContext;
        public DepartmentReposotiry(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Department> Get(int id) => await _dbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Department> GetAll() => _dbContext.Departments;


        public async Task<Department> Create(Department entity)
        {
            if(entity == null) { return null!; }
            try
            {
                await _dbContext.Departments.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

        public async Task<Department> Update(Department entity)
        {
            if (entity == null) { return null!; }
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

        public async Task<Department> Delet(Department entity)
        {
            if (entity == null) { return null!; }
            try
            {
                _dbContext.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

    }
}
