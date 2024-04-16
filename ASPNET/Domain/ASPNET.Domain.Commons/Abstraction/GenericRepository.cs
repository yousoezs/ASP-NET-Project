using ASPNET.Domain.Commons.Interface;
using ASPNET.Domain.Commons.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Abstraction
{
    /// <summary>
    /// Use this project libray to reference in your APIs to create your own repository classes. In this case, you create your Repository class
    /// and inherit this one, pass in your DBContext and implement the abstract methods.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public abstract class GenericRepository<TContext> : IGenericRepository<IEntity<Guid>, Guid>
    {
        protected TContext dbContext;
        public GenericRepository(TContext dbContext) => this.dbContext = dbContext;
        public abstract Task<ServiceResponse<IEntity<Guid>>> AddEntity(IEntity<Guid> entity);
        public abstract Task<ServiceResponse<IEntity<Guid>>> DeleteEntity(Guid id);
        public abstract Task<ServiceResponse<IEnumerable<IEntity<Guid>>>> GetAllEntities();
        public abstract Task<ServiceResponse<IEntity<Guid>>> GetEntity(Guid id);
        public abstract Task<ServiceResponse<IEntity<Guid>>> UpdateEntity(IEntity<Guid> entity);
    }
}
