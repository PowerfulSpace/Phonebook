using Microsoft.EntityFrameworkCore;
using PS.Phonebook.DAL.Data;
using PS.Phonebook.DAL.Interfaces;
using PS.Phonebook.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Repositories
{
    public class PositionRepository : IPosition
    {
        private readonly ApplicationDbContext _dbContext;
        public PositionRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;


        public async Task<Position> GetAsync(int id) => await _dbContext.Positions.FirstOrDefaultAsync(x => x.Id == id);

        public IQueryable<Position> GetAll() => _dbContext.Positions;


        public async Task<Position> CreateAsync(Position entity)
        {
            if (entity == null) { return null!; }
            try
            {
                await _dbContext.Positions.AddAsync(entity);
                _dbContext.Entry(entity).State = EntityState.Added;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception) { }

            return entity;
        }

        public async Task<Position> UpdateAsync(Position entity)
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

        public async Task<Position> DeletAsync(Position entity)
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
