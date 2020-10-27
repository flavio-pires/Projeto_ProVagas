using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProVagas.Interfaces
{
        public interface IRepositoryBase<TEntity> where TEntity : class
        {
            void Add(TEntity obj);
            void Update(TEntity obj);
            void Delete(TEntity obj);
            IEnumerable<TEntity> GetAll();
            TEntity GetById(int id);
        }
}
