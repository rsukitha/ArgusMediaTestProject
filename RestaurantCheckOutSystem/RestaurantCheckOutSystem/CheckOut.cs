namespace RestaurantCheckOutSystem
{

    public class CheckOut
    {
        // Constants
        double SERVICE_CHARGE_PERCENT = 0.1;
        double DRINKS_REDUCED_PERCENT = 0.7;
        string DRINKS = "drinks";
        
        List<Order> orderList = new List<Order>();

        public void AddOrder(List<Order> orders)
        {
            foreach(Order order in orders)
            {
                orderList.Add(order);
            }
        }

        private double getMenuItemPrice(string itemName)
        {
            var menuPrices = new Menu();
            return menuPrices[itemName];
        }

        public void UpdateOrder(List<Order> orders)
        {
            List<Order> drinksOrder = orderList.Where(order => order.Type.ToLower() == DRINKS).ToList();
            orderList = new List<Order>(orders);

            foreach(Order order in orderList)
            {
                if(order.Type.ToLower() == DRINKS) {
                    order.OrderTime = drinksOrder[0].OrderTime;
                }
            }
        }

        public List<bool> wasDiscountapplied()
        {
            List<bool> discount = new List<bool>();

            foreach (Order order in orderList)
            {
                if(order.Type== DRINKS)
                {
                    bool isDiscount = (order.OrderTime > 0 && order.OrderTime < 19) ? true : false;
                    discount.Add(isDiscount);
                }
                
            }

            return discount;
        }

        public double getTotal()
        {
            double total = 0.0;

            foreach (Order order in orderList)
            {
                bool discounted = order.OrderTime > 0 && order.OrderTime < 19;
                string item = order.Item.ToLower();
                double menuItemCost = getMenuItemPrice(item);

                // 30% discount if drinks ordered before 19
                double itemPrice = (discounted && order.Type == DRINKS) ? menuItemCost * DRINKS_REDUCED_PERCENT * order.Count : menuItemCost * order.Count;
                total += itemPrice;
            }

            // Add 10% service charge
            total += total * SERVICE_CHARGE_PERCENT;
            return total;
            
        }



    }
}