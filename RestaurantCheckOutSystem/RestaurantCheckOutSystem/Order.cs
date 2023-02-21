namespace RestaurantCheckOutSystem
{
    public class Order
    {
        private string item;
        private string type;
        private int count;
        private int orderTime;

        public string Item { get => item; set => item = value; }

        public string Type { get => type; set => type = value; }
        public int Count { get => count; set => count = value; }
        public int OrderTime { get => orderTime; set => orderTime = value; }
    }
}
