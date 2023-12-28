public class Solution {
    public long solve(int n, int k, int target) {
        var dp = new long[n + 1, target + 1];
        long mod = (long)(1e9 + 7);
        dp[0, 0] = 1;
        
        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= target; j++) {
                for (int l = 1; l <= k; l++) {
                    if (j >= l) {
                        dp[i, j] = (dp[i, j] + dp[i - 1, j - l]) % mod;
                    }
                }
            }
        }
        return dp[n, target];
    }

    public int NumRollsToTarget(int n, int k, int target) {
        return (int)solve(n, k, target); 
    }
}
public class SolutionTwo {
    public int NumRollsToTarget(int n, int k, int target) {
        var dp=new int[target+1];
        dp[0]=1;

        for(int i=1;i<=n;i++){
            var tmp=new int[dp.Length];

            for(int j=1;j<=target;j++){
                if(j>i*k) continue;

                for(int m=1;m<=k&&m<=j;m++){
                    tmp[j]=(tmp[j]+dp[j-m])%1_000_000_007;
                }
            }
            dp=tmp;
        }
        return dp[target];
    }
}
public class SolutionThree {
    public int NumRollsToTarget(int n, int k, int target) {
        if (n * k < target) return 0;
        var map = new Dictionary<int, long>();
        if (k > target) k = target;
        for (var i = 1; i <= k; ++i) map[i] = 1;
        for (var i = 2; i <= n; ++i)
        {
            var newMap = new Dictionary<int, long>();
            for (var j = 1; j <= k; ++j)
            {
                foreach (var key in map.Keys)
                {
                    var newKey = key + j;
                    if (newKey > target) continue;
                    if (!newMap.ContainsKey(newKey)) newMap[newKey] = 0;
                    newMap[newKey] = (newMap[newKey] + map[key]) % 1000000007;
                }
            }
            map = newMap;
        }
        return (int)map[target];
    }
}