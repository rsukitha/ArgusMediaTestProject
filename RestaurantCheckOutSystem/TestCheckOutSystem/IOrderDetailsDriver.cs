namespace TestCheckOutSystem
{
    public interface IOrderDetailsDriver
    {
        void addOrder(Table order);
        double getTotal();

        void updateOrder(Table order);

        List<bool> wasDiscountApplied();
    }
}
