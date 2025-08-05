using ECommerceWebAPI.Domain.Interfaces;
using ECommerceWebAPI.Domain.Models.Entities;
using ECommerceWebAPI.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceWebAPI.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Order> _dbSet;
        public OrderRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        public async Task<Order> GetOrderWithDetails(int id)
        {
            return  await _dbSet.Where(x=>x.Id == id).Include(x=>x.Customer).Include(x=>x.OrderProducts).FirstOrDefaultAsync();
        }

       
    }
}
