using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private StoreDbContext context;

        public EFOrderRepository(StoreDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.Orders
                                    .Include(o => o.Lines)
                                    .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            // Attach any products that are already in the database
            context.AttachRange(order.Lines.Select(l => l.Product));
            
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            
            context.SaveChanges();
        }
    }
}