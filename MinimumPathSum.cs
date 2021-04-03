// https://leetcode.com/problems/minimum-path-sum/

class Solution
{
      //Recursive with memo.
      //minPath(0,0)=grid(0,0)
      //minPath(i,j) = grid(i,j) + min(minPath(i-1,j), minPath(i,j-1))
      //time, space, O(mn)
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
      
      //DP
      //minPath(0,0)=grid(0,0)
      //minPath(0,j)=grid(0,j) + minPath(0, j-1)
      //minPath(i,0)=grid(i,0) + minPath(i-1, 0)
      //minPath(i,j) = grid(i,j) + min(minPath(i-1,j), minPath(i,j-1))
      //time: O(mn), space O(1)
      public int MinPathSumDP(int[][] grid)
      {
            if(grid.Length<=0)
                  return 0;
            var rowNum = grid.Length;
            var colNum = grid[0].Length;
            for(var i=0; i<rowNum; i++)
            {
                  for(var j=0; j<colNum; j++)
                  {
                        if(i==0 && j==0) continue;
                        if(i==0) grid[0][j] += grid[0][j-1];
                        else if(j==0) grid[i][0] += grid[i-1][0];
                        else grid[i][j] += Math.Min(grid[i-1][j], grid[i][j-1]);
                  }
            }
            return grid[rowNum-1][colNum-1];
      }
}
