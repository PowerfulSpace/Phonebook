using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class SubdivisionRepository : ISubdivision
    {
        private readonly ApplicationDbContext _dbContext;
        public SubdivisionRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Subdivision> GetAsync(int id) => await _dbContext.Subdivisions.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Subdivision> GetAll() => _dbContext.Subdivisions;


        public async Task<Subdivision> CreateAsync(Subdivision entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Subdivisions.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Subdivision> UpdateAsync(Subdivision entity)
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

        public async Task<Subdivision> DeletAsync(Subdivision entity)
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
