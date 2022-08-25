using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class Organization2Reposotiry : IOrganization2
    {
        private readonly ApplicationDbContext _dbContext;
        public Organization2Reposotiry(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Organization2> Get(int id) => await _dbContext.Organizations2.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Organization2> GetAll() => _dbContext.Organizations2;


        public async Task<Organization2> Create(Organization2 entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Organizations2.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e) { }

            return entity;
        }

        public async Task<Organization2> Update(Organization2 entity)
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

        public async Task<Organization2> Delet(Organization2 entity)
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
