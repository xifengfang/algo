# https://leetcode.com/problems/reverse-pairs/
# https://www.youtube.com/watch?v=TXOXKILPMVI
# https://www.youtube.com/watch?v=j68OXAMlTM4

class Solution {
    public int ReversePairs(int[] nums) {
        int n = nums.Length;
        return MergeSort(nums, 0, n - 1);
    }

    private int MergeSort(int[] nums, int lo, int hi) {
        if (lo >= hi) return 0;
        int res = 0;
        int mid = lo + (hi - lo) / 2;
        res += MergeSort(nums, lo, mid);
        res += MergeSort(nums, mid + 1, hi);

        res += Merge(nums, lo, mid, hi);
        return res;
    }

    private int Merge(int[] nums, int lo, int mid, int hi) {
        int count = 0;
        int[] a = new int[hi - lo + 1];
        int index = 0;
        int p = lo, q = mid + 1;
        while (p <= mid && q <= hi) {
            if ((long) nums[p] > 2 * (long) nums[q]) {
                count += mid - p + 1;
                q++;
            } else {
                p++;
            }
        }
        p = lo;
        q = mid + 1;

        while (p <= mid && q <= hi) {
            if (nums[p] > nums[q]) {
                a[index++] = nums[q];
                q++;
            } else {
                a[index++] = nums[p++];
            }
        }

        while (p <= mid) {
            a[index++] = nums[p++];
        }

        while (q <= hi) {
            a[index++] = nums[q++];
        }

        Array.Copy(a, 0, nums, lo, hi - lo + 1);
        return count;
    }
}
