# https://leetcode.com/problems/unique-paths/
# https://www.youtube.com/watch?v=fmpP5Ll0Azc
 
public class Solution {
    Dictionary<(int,int), int> _f = new Dictionary<(int, int), int>();
    public int UniquePaths(int m, int n)
    {
        if (m < 0 || n < 0) return 0;
        if (m == 1 && n == 1) return 1;
        if (_f.TryGetValue((m, n), out int _cacheVal))
            return _cacheVal;
        int left_paths = UniquePaths(m - 1, n);
        int top_paths = UniquePaths(m, n - 1);
        _f[(m,n)] = left_paths + top_paths;
        return _f[(m, n)];
    }
}
