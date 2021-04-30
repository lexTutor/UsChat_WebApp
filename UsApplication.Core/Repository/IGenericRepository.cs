using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UsApplication.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity model);
        Task<TEntity> GetById(object Id);
        Task<bool> Modify(TEntity entity);
        Task<bool> DeleteById(TEntity model);
    }
}
