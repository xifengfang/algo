// https://leetcode.com/problems/daily-temperatures/
// https://www.youtube.com/watch?v=d4FvlTzzWjQ

public class Solution {
    public int[] DailyTemperatures(int[] T) {
        Stack<int> stack = new Stack<int>();
        int[] res = new int[T.Length];
        for(var i=0; i<T.Length; i++){
            while(stack.Count>0 && T[stack.Peek()]<T[i])
            {
                var ind = stack.Pop();
                res[ind] = i-ind;
            }
            stack.Push(i);
        }
        while(stack.Count>0){
            var ind = stack.Pop();
            res[ind] = 0;
        }
        return res;
    }
}
