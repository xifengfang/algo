// https://leetcode.com/problems/edit-distance/
// https://www.youtube.com/watch?v=Q4i_rqON2-E

class Solution {
    public int minDistance(String word1, String word2) {
        int l1 = word1.length();
        int l2 = word2.length();
        int[][] dp = new int[l1][l2];
        for(int i=0; i<l1; i++) {
            for(int j=0; j<l2; j++) {
                dp[i][j] = -1;
            }
        }
        return _minDist(word1, word2,l1,l2,dp);
    }
    public int _minDist(String word1, String word2, int l1, int l2, int[][] dp) {
        if(l1==0) return l2;
        if(l2==0) return l1;
        if(dp[l1-1][l2-1]>=0) return dp[l1-1][l2-1];
        int dist = 0;
        if(word1.charAt(l1-1) == word2.charAt(l2-1)) {
            dist = _minDist(word1,word2,l1-1,l2-1,dp);
        } else {
            int dist1 = _minDist(word1,word2,l1-1,l2,dp);
            int dist2 = _minDist(word1,word2,l1,l2-1,dp);
            int dist3 = _minDist(word1,word2,l1-1,l2-1,dp);
            dist = Math.min(dist1, Math.min(dist2,dist3)) + 1;
        }
        dp[l1-1][l2-1] = dist;
        return dist;
    }
}
