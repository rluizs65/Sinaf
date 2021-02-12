using Base.Core.Entities.Interfaces;

namespace Base.Core.Entities
{
    public abstract class BaseEntity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        protected BaseEntity()
        {

        }

        public virtual TPrimaryKey Id { get; set; }
    }
}
