using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Base
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        TEntity GetById(TEntity entity);
        IEnumerable<TEntity> GetAll();
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
    }
}
