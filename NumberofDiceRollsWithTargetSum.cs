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
