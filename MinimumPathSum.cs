# https://leetcode.com/problems/minimum-path-sum/

class Solution
{
      #Recursive with memo.
      public int MinPathSum(int[][] grid)
      {
          if (grid.Length <= 0)
              return 0;
          var rowNum = grid.Length;
          var colNum = grid[0].Length;
          Dictionary<(int, int), int> dp = new Dictionary<(int, int), int>();
          return _getPathSum(grid, rowNum - 1, colNum - 1, rowNum, colNum, dp);
      }
      private int _getPathSum(int[][] grid, int row, int col, int rowNum, int colNum, Dictionary<(int,int), int> dp)
      {
          if (row == 0 && col == 0) return grid[row][col];
          if (row < 0 || col < 0) return int.MaxValue;
          if (dp.TryGetValue((row, col), out int val)) return val;
          val = grid[row][col] + Math.Min(_getPathSum(grid, row - 1, col, rowNum, colNum, dp), _getPathSum(grid, row, col - 1, rowNum, colNum, dp));
          dp[(row, col)] = val;
          return val;
      }
      
      #DP
      
}
