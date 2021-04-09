// https://www.geeksforgeeks.org/check-if-a-given-sequence-of-moves-for-a-robot-is-circular-or-not/
// modification: once the robot has completed the list of instructions, it will repeat them in an infinite loop.
public class Robot
{
    public static List<String> doesCircleExist(List<String> commands) {
        List<String> res = new ArrayList<String>();
        for (String command : commands) {
            res.add(isCircular(command) ? "YES" : "NO");
        }
        return res;
    }
    public static boolean isCircular(String str){
        char[] path = str.toCharArray();
        int x =0, y=0;
        int dir =0;
        for(int j=0; j<4; j++)
        {
            for(int i=0; i<path.length; i++){
                char move = path[i];
                if(move == 'R'){
                    dir = (dir + 1)%4;
                }
                else if(move == 'L'){
                    dir = (4 + dir -1)%4;
                }
                else{
                    if(dir ==0)
                        y++;
                    else if(dir ==1)
                        x++;
                    else if(dir ==2)
                        y--;
                    else
                        x--;
                }
            }
            if(x==0 && y==0)
                return true;
        }
        return (x==0 && y==0);
    }
}
