using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    /// <summary>
    /// Use the IUnitOfWork only if you want to upgrade your repository pattern to follow UoW pattern.
    /// </summary>
    /// <typeparam name="TRepository"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IUnitOfWork<TRepository, TEntity, TId> where TRepository : 
        IGenericRepository<TEntity, TId> where TEntity : 
        IEntity<TId>, 
        IDisposable
    {
    }
}
