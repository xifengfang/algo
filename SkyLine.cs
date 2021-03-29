#https://leetcode.com/problems/the-skyline-problem/
#inspired by https://www.youtube.com/watch?v=8Kd-Tn_Rz7s


class Solution
{
    private MaxHeap heap;

         public List<int[]> GetSkyline(int[][] buildings)
        {
            int n = buildings.Length;
            // {x, h, id}
            List<int[]> es = new List<int[]>();


            for (int i = 0; i < n; ++i)
            {
                es.Add(new int[] { buildings[i][0], buildings[i][2], i });
                es.Add(new int[] { buildings[i][1], -buildings[i][2], i });
            }

            es.Sort((e1,e2) => { return e1[0] == e2[0] ? e2[1] - e1[1] : e1[0] - e2[0]; });

            List<int[]> ans = new List<int[]>();

            heap = new MaxHeap();

            foreach(var e in es)
            {
                int x = e[0];
                int h = e[1];
                int id = e[2];

                Boolean entering = h > 0;
                h = Math.Abs(h);

                if (entering)
                {
                    if (h > heap.Max())
                        ans.Add(new int[] { x, h });
                    heap.Add(h);
                }
                else
                {
                    heap.Remove(h);
                    if (h > heap.Max())
                        ans.Add(new int[] { x, heap.Max() });
                }
            }

            return ans;
        }

        private class MaxHeap
        {
            private SortedSet<int> sortedSet;
            private IDictionary<int, int> dict;

            public int Count { get; set; }

            public MaxHeap()
            {
                sortedSet = new SortedSet<int>();
                dict = new Dictionary<int, int>();
            }

            public void Add(int item)
            {
                if (!dict.ContainsKey(item))
                {
                    dict[item] = 0;
                }
                sortedSet.Add(item);
                dict[item]++;
                Count++;
            }

            public int Max()
            {
                return sortedSet.Max;
            }

            public void Remove(int item)
            {
                if (!dict.ContainsKey(item))
                {
                    return;
                }

                if (--dict[item] == 0)
                {
                    dict.Remove(item);
                    sortedSet.Remove(item);
                }

                Count--;
            }
        }
}
