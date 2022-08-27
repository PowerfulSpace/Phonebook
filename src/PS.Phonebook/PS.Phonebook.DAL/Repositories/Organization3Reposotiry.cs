using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class Organization3Reposotiry : IOrganization3
    {
        private readonly ApplicationDbContext _dbContext;
        public Organization3Reposotiry(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Organization3> GetAsync(int id) => await _dbContext.Organizations3.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Organization3> GetAll() => _dbContext.Organizations3;


        public async Task<Organization3> CreateAsync(Organization3 entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Organizations3.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

        public async Task<Organization3> UpdateAsync(Organization3 entity)
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

        public async Task<Organization3> DeletAsync(Organization3 entity)
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
