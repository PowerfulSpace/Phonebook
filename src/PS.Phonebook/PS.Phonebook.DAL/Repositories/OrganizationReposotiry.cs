using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class OrganizationReposotiry : IOrganization
    {
        private readonly ApplicationDbContext _dbContext;
        public OrganizationReposotiry(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Organization> Get(int id) => await _dbContext.Organizations.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Organization> GetAll() => _dbContext.Organizations;


        public async Task<Organization> Create(Organization entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Organizations.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

        public async Task<Organization> Update(Organization entity)
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

        public async Task<Organization> Delet(Organization entity)
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
