using System;
using apshop.Repositories.UnitOfWork;
using apshop.Repositories.Interfaces;
using apshop.Repositories.Repositories;
using apshop.Data;

namespace apshop.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApShopContext _context;
        private UserRepository _user;
        private ItemRepository _item;
        private CategoryRepository _category;
        private CartRepository _cart;
        private OrderRepository _order;

        public UnitOfWork(ApShopContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context was not supplied");
            }
            _context = context;
        }

        public IUserRepository user
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public IItemRepository item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_context);
                }
                return _item;
            }
        }


        public ICategoryRepository category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }
                return _category;
            }
        }

     
        public IOrderRepository order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }

        public ICartRepository cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_context);
                }
                return _cart;
            }
        } 

        public void Commit()
        {
           _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
