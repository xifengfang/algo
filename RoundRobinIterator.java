/*
mplement a robin robin iterator in Python which takes in a list of lists and has:
hasNext() to return boolean if there is a next element
next() to return/print the next element

The round robin iterator iterates irrespective of if every list is not the same size

# example
a = ['a1','a2','a3']
b = ['b1']
c = ['c1','c2','c3','c4']
round_robin([a,b,c])

round_robin.hasNext()
round_robin.next()
# print example
['a1','b1','c1','a2','c2','a3','c3','c4']
*/

public class IndexPair {
    public int cur_list;
    public int cur_idx;
    public IndexPair(int cur_list, int cur_idx) {
      this.cur_list = cur_list;
      this.cur_idx = cur_idx;
    }
}

class RoundRobinIterator<T> implement Iterator {
  private List<Iterator> iters;
  private List<IndexPair> indexQueue = new LinkedList<>();
  public RoundRobinIterator(List<Iterator> iters) {
    this.iters = iters;
    for(int i=0; i<iters.length(); i++){
      indexQueue.add(new IndexPair(i,0));
    }
  }
  public boolean hasNext() {
    return indexQueue.size()!=0;
  }
  public T next() {
    IndexPair indexPair = indexQueue.poll();
    int cur_list = indexPair.cur_list;
    int cur_idx = indexPair.cur_idx;
    if(cur_idx + 1 != iters.get(cur_list).length()) {
      indexQueue.add(new IndexPair(cur_list, cur_idx + 1));
    }
    return iters.get(cur_list).get(cur_idx);
  }
}
        
        
        
