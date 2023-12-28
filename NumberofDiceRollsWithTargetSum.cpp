#include <iostream>
#include <vector>
#include <cmath>

class Solution {
public:

    long long solve(int n, int k, int target){
        std::vector<long long> previous(target+1, 0);
        std::vector <long long> current(target+1, 0);
        previous[0] =1;

       const int mod = 1e9+7;

        for(int i = 1; i<=n; i++){

            for(int j=1; j<=target;j++){

                long long ans = 0;

                for(int l = 1; l<=k;l++){

                    if((j-l)>=0){
                        ans= ans + previous[j-l] % mod;

                    }
                }
                current[j]= ans;

            }
        previous= current;
        }
   return (previous[target] % mod);
    
    }
    int numRollsToTarget(int n, int k, int target) {
     return solve(n, k, target);   
    }
};