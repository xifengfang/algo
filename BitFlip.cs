//https://leetcode.com/problems/minimum-flips-to-make-a-or-b-equal-to-c/


public class Solution {
    public int MinFlips(int a, int b, int c) {
        int ans = 0;
        while(a!=0 || b!=0 || c!=0){
            int bita = a&1;
            int bitb = b&1;
            int bitc = c&1;
            if(bitc==0){
                ans += bita + bitb;
            }
            else if((int)(bita|bitb) ==0){
                ans +=1;
            }
            a >>=1;
            b >>=1;
            c >>=1;
        }
        return ans;
    }
}
