//https://leetcode.com/problems/word-break-ii/solution/


class Solution {
    Set<String> wSet = new HashSet();
    Set<Integer> wLenSet = new HashSet();
    List<String> res = new ArrayList();
    int n;
        
    public List<String> wordBreak(String s, List<String> wordDict) {
        n = s.length();
        for (String word : wordDict) {
            wSet.add(word);
            wLenSet.add(word.length());
        }
        backtrack(s, 0, new LinkedList<String>());
        return res;
    }
    
    private void backtrack(String s, int start, LinkedList<String> words) { 
        if (start == n) {
            res.add(String.join(" ", words));
            return;
        } else {
            for (int wlen : wLenSet) { 
                int end = start + wlen;
                if (end <= n) {
                    String word = s.substring(start, end);
                    if (wSet.contains(word)) {
                        words.addLast(word);
                        backtrack(s, end, words); 
                        words.removeLast();
                    }   
                }
            }
        }
    }
}
