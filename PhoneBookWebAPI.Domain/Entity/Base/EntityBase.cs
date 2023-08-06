using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebAPI.Domain.Entity.Base
{
    public abstract class EntityBase<T> : IEntity<T>
    {
        public T Id { get; set; }
    }

    public abstract class EntityBase : EntityBase<int>
    {
    }

    public interface IEntity<T>
    {
        T Id { get; set; }
    }

}
