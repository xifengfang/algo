// https://leetcode.com/problems/edit-distance/
// https://www.youtube.com/watch?v=Q4i_rqON2-E

public class Solution {
    public int MinDistance(string word1, string word2) {
        var n1 = word1.Length;
        var n2 = word2.Length;
        int[,] dp = new int[n1,n2];
        for(var i=0; i<n1; i++)
        {
            for(var j=0; j<n2; j++)
            {
                dp[i,j] = -1;
            }
        }
        return _minDist(word1,word2,n1,n2,dp);
    }
    private int _minDist(string word1,string word2,int l1,int l2, int[,]dp){
        if(l1==0) return l2;
        if(l2==0) return l1;
        if(dp[l1-1,l2-1]>=0) return dp[l1-1,l2-1];
        
        var min_len = 0;
        if(word1[l1-1]==word2[l2-1])
        {
            min_len = _minDist(word1,word2,l1-1,l2-1,dp);
        }
        else
        {
            var dist1 = _minDist(word1,word2,l1-1,l2-1,dp);
            var dist2 = _minDist(word1,word2,l1,l2-1,dp);
            var dist3 = _minDist(word1,word2,l1-1,l2,dp);
            min_len = Math.Min(dist1, Math.Min(dist2, dist3)) + 1;
        }
        dp[l1-1,l2-1] = min_len;
        return min_len;
    }
}
