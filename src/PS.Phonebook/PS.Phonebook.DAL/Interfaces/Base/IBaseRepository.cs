using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        public Task<T> CreateAsync(T entity);
        public Task<T> GetAsync(int id);
        public IQueryable<T> GetAll();
        public Task<T> DeletAsync(T entity);
        public Task<T> UpdateAsync(T entity);
    }
}
