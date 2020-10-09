using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcoHippiesBackend.Interfaces
{
    interface IRepository<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        abstract Task<IList<TDto>> Read();
        abstract Task<TDto> ReadById(int Id);
        abstract Task<TEntity> Update(TEntity value);
        abstract Task<TEntity> Delete(TEntity value);
        abstract Task<TEntity> Delete(int Id);
        abstract Task<TEntity> Create(TEntity value);
    }
}
