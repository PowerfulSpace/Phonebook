using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class Organization1Repository : IOrganization1
    {
        private readonly ApplicationDbContext _dbContext;
        public Organization1Repository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Organization1> GetAsync(int id) => await _dbContext.Organizations1.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Organization1> GetAll() => _dbContext.Organizations1;


        public async Task<Organization1> CreateAsync(Organization1 entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Organizations1.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Organization1> UpdateAsync(Organization1 entity)
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

        public async Task<Organization1> DeletAsync(Organization1 entity)
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
