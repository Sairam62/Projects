
namespace DSA;

public class StocksBuySell : BaseQuestion
{
    public override void Handle()
    {
        int[] prices = [7,1,5,3,6,4];
        Optimal(prices);
    }

    private void Optimal(int[] prices)
    {
        int profit = 0;
        int Min = int.MaxValue;
        for(int i=0;i<prices.Length;i++)
        {
            Min = Math.Min(Min,prices[i]);
            profit = Math.Max(profit,prices[i]-Min);
        }
        Console.WriteLine(profit);
    }
}
