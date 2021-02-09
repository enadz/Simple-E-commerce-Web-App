using System;
using System.Collections.Generic;
using System.Text;
using apshop.Repositories.Interfaces;

namespace apshop.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository user { get; }
        ICategoryRepository category { get; }
        IItemRepository item { get; }
        IOrderRepository order { get; }
        ICartRepository cart { get; }

        public void Commit();
       
    }
}
