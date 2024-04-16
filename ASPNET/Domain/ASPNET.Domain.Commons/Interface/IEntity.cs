using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET.Domain.Commons.Interface
{
    /// <summary>
    /// Use the IEntity interface for your DTOs and Database models to easily identify the Id property.
    /// Also use this interface to create your own Repository classes
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<out T>
    {
        public T Id { get; }
    }
}
