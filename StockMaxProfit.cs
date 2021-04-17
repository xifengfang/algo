// https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
// DP problem
// https://www.youtube.com/watch?v=8pVhUpF1INw&t=0s

public class Solution {
    public int MaxProfit(int[] prices) {
        var maxProfit = 0;
        var minPrice = prices[0];
        for(var i=1; i<prices.Length; i++){
            minPrice = Math.Min(minPrice, prices[i]);
            maxProfit = Math.Max(maxProfit, prices[i]-minPrice);
        }
        return maxProfit;
    }
}
