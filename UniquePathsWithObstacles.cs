    class Solution
    {
        Dictionary<(int, int), int> _f = new Dictionary<(int, int), int>();
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            var rows = obstacleGrid.Length;
            var cols = obstacleGrid[0].Length;

            return _UniquePathsWithObstacles(rows - 1, cols - 1, obstacleGrid);
        }

        private int _UniquePathsWithObstacles(int x, int y, int[][] obstacleGrid)
        {
            if (x < 0 || y < 0) return 0;
            if (x == 0 && y == 0) return 1-obstacleGrid[x][y];
            if (_f.TryGetValue((x, y), out int _cacheVal))
                return _cacheVal;
            int left_paths = _UniquePathsWithObstacles(x - 1, y, obstacleGrid);
            int top_paths = _UniquePathsWithObstacles(x, y - 1, obstacleGrid);
            _f[(x, y)] = left_paths + top_paths;
            return _f[(x, y)];
        }
    };
