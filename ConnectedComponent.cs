// https://leetcode.com/problems/number-of-connected-components-in-an-undirected-graph/
//get connect component in a undirected graph  
public class ConnectedSum
 {
     public void Test()
     {
         string[] edges = new string[] { "8 1", "5 8", "7 3", "8 6"};
         var res = GetConnectedComponents(8, edges);
     }
     private void dfs(List<int>[] adjList, int[] visited, int startNode, List<int> linked)
     {
         visited[startNode] = 1;

         for (int i = 0; i < adjList[startNode].Count; i++)
         {
             if (visited[adjList[startNode][i]] == 0)
             {
                 dfs(adjList, visited, adjList[startNode][i], linked);
             }
         }
         linked.Add(startNode);

     }

     public List<List<int>> GetConnectedComponents(int n, string[] edges)
     {
         int[] visited = new int[n+1];

         List<int>[] adjList = new List<int>[n+1];
         for (int i = 1; i < n+1; i++)
         {
             adjList[i] = new List<int>();
         }

         for (int i = 0; i < edges.Length; i++)
         {
             var edge = edges[i].Split(' ');
             var v1 = int.Parse(edge[0]);
             var v2 = int.Parse(edge[1]);
             adjList[v1].Add(v2);
             adjList[v2].Add(v1);
         }

         List<List<int>> res = new List<List<int>>();
         for (int i = 1; i <= n; i++)
         {
             if (visited[i] == 0)
             {
                 var linked = new List<int>();
                 dfs(adjList, visited, i, linked);
                 res.Add(linked);
             }
         }
         return res;
     }
 }
