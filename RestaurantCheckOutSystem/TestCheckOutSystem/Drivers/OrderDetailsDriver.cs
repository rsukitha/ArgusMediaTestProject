using RestaurantCheckOutSystem;
using TechTalk.SpecFlow.Assist;

namespace TestCheckOutSystem.Drivers
{
    internal class OrderDetailsDriver : IOrderDetailsDriver
    {
        private readonly CheckOut _restaurantCheckOutSystem;

        public OrderDetailsDriver(CheckOut restaurantCheckOutSystem)
        {
            _restaurantCheckOutSystem = restaurantCheckOutSystem;
        }

        public void addOrder(Table order)
        {
            var rows = order.CreateSet<Order>();
            List<Order> ordersToAdd = new List<Order>();

            foreach (var row in rows)
            {
                var order_item = new Order
                {
                    Item = row.Item,
                    Type= row.Type,
                    Count = row.Count,
                    OrderTime = row.OrderTime
                };

                ordersToAdd.Add(order_item);
            }

            _restaurantCheckOutSystem.AddOrder(ordersToAdd);
        }

        public double getTotal()
        {
            return _restaurantCheckOutSystem.getTotal();
        }

        public void updateOrder(Table order)
        {
            var rows = order.CreateSet<Order>();
            List<Order> ordersToUpdate = new List<Order>();

            foreach (var row in rows)
            {
                var orderToUpdate = new Order
                {
                    Item = row.Item,
                    Type= row.Type, 
                    Count = row.Count,
                    OrderTime = row.OrderTime
                };

                ordersToUpdate.Add(orderToUpdate);

            }
            _restaurantCheckOutSystem.UpdateOrder(ordersToUpdate);
        }

        public List<bool> wasDiscountApplied()
        {
            return _restaurantCheckOutSystem.wasDiscountapplied();
        }
    }
}
