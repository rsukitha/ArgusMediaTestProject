namespace RestaurantCheckOutSystem
{
    public class Menu
    {
        private readonly IDictionary<string, double> _prices = new Dictionary<string, double>
        {
            { "starters", 4.0 },
            { "main", 7.0 },
            { "drinks", 2.50 }
        };

        private readonly IDictionary<string, string> _items = new Dictionary<string, string>
        {
            { "springroll", "starters" },
            { "samosa", "starters" },
            { "chips", "starters" },
            { "hashbrown", "starters" },
            { "chickenlolipop", "starters" },
            { "aloogobi", "main" },
            { "pasta", "main" },
            { "pizza", "main" },
            { "lasagna", "main" },
            { "burger", "main" },
            { "coke", "drinks" },
            { "pepsi", "drinks" },
            { "sevenup", "drinks" },
            { "sprite", "drinks" }
        };

        public double this[string key]
        {
            get { return _prices[_items[key]]; }
        }
    }
}
