// https://leetcode.com/problems/set-matrix-zeroes/
// https://www.youtube.com/watch?v=-I8w2_sN93c


public class Solution {
    //space O(1)
    public void SetZeroes(int[][] matrix) {
        bool firstRowZero = false, firstColZero =false;
        var row_num = matrix.Length;
        var col_num = matrix[0].Length;
        
        //check first row 0
        for(var i=0; i<col_num; i++)
        {
            if(matrix[0][i]==0)
            {
                firstRowZero = true;
                break;
            }
        }
        
        //check first col 0
        for(var i=0; i<row_num; i++)
        {
            if(matrix[i][0]==0)
            {
                firstColZero = true;
                break;
            }
        }
        
        //check other cell and use the first row/col as marker
        for(var i=1; i<row_num; i++)
        {
            for(var j=1; j<col_num; j++)
            {
                if(matrix[i][j]==0)
                {
                    matrix[0][j] = 0;
                    matrix[i][0] = 0;
                }
            }
        }
        
        //set 0 for other cells
        for(var i=1; i<row_num; i++)
        {
            for(var j=1; j<col_num; j++)
            {
                if(matrix[0][j]==0 || matrix[i][0]==0)
                    matrix[i][j] = 0;
            }
        }
        
        //set 0 for first row
        if(firstRowZero)
        {
            for(var i=0; i<col_num; i++)
                matrix[0][i] = 0;
        }
        
        //set 0 for first col
        if(firstColZero)
        {
            for(var i=0; i<row_num; i++)
                matrix[i][0] = 0;
        }
    }
    
    //space: O(M+N)
    public void SetZeroes2(int[][] matrix) {
        var map_rows = new HashSet<int>();
        var map_cols = new HashSet<int>();
        var row_num = matrix.Length;
        var col_num = matrix[0].Length;
        for(var i=0; i<row_num; i++)
        {
            for(var j=0; j<col_num; j++)
            {
                if(matrix[i][j]==0)
                {
                    map_rows.Add(i);
                    map_cols.Add(j);
                }
            }
        }
        for(var i=0; i<row_num; i++)
        {
            for(var j=0; j<col_num; j++)
            {
                if(map_rows.Contains(i) || map_cols.Contains(j))
                    matrix[i][j] = 0;
            }
        }
    }
}
