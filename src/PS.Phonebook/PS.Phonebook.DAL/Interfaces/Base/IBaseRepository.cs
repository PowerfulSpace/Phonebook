using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Interfaces.Base
{
    public interface IBaseRepository<T>
    {
        public Task<bool> Create(T entity);
        public Task<T> Get(Guid id);
        public IQueryable<T> GetAll();
        public Task<bool> Delet(T entity);
        public Task<T> Update(T entity);
    }
}
