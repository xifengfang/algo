//https://leetcode.com/discuss/interview-question/1042645/amazon-oa-storage-optimization-optimizing-box-weight

class Result{
      public static List<Integer> minimalHeaviestSetA(List<Integer> arr) {        
        List<Integer> res = new ArrayList<Integer>();
        Collections.sort(arr, Collections.reverseOrder());
        int len = arr.size();
        double setAWeight = 0;
        double totalWeight = 0;
        for(int i=0; i<len; i++){
            totalWeight += (double)arr.get(i);
        }
        for(int i=0; i<len; i++){
            int val = arr.get(i);
            setAWeight += (double)val;
            res.add(val);
            if(setAWeight>totalWeight/2) break;
        }
        Collections.sort(res);
        return res;
    }
}
