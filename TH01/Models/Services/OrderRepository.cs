using TH01.Data;
using TH01.Models.Interfaces;
namespace TH01.Models.Services
{
    public class OrderRepository : IOrderRepository
    {
        private CoffeeshopDbContext DbContext;
        private IShoppingCartRepository shoppingCartRepository;

        public OrderRepository(CoffeeshopDbContext DbContext, IShoppingCartRepository shoppingCartRepository)
        {
            this.DbContext = DbContext;
            this.shoppingCartRepository = shoppingCartRepository;
        }

        public void PlaceOrder(Order Order)
        {
            var shoppingCartItems = shoppingCartRepository.GetAllShoppingCartItems();
            Order.OrderDetails = new List<OrderDetail>();

            foreach (var item in shoppingCartItems)
            {
                var OrderDetail = new OrderDetail
                {
                    Quantity = item.Qty,
                    ProductId = item.Product.Id,
                    Price = item.Product.Price
                };
                Order.OrderDetails.Add(OrderDetail);
            }

            Order.OrderPlaced = DateTime.Now;
            Order.OrderTotal = shoppingCartRepository.GetShoppingCartTotal();
            DbContext.Orders.Add(Order);
            DbContext.SaveChanges();
        }
    }
}
