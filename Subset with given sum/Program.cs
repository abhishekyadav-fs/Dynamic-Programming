using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubsetWithGivenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 2, 4, 6, 10 };
            int sum = 16; ;
            int result = FindSubSet(arr, sum, arr.Length - 1);
            Console.WriteLine(result);

            // Memo
            Dictionary<string, int> memo = new Dictionary<string, int>();
            result = FindSubSetDP(arr, sum, arr.Length-1, memo);
            Console.WriteLine("Dp-"+ result);
            Console.ReadKey();
        }

        // Recusive Solution
        public static int FindSubSet(int[] arr,int sum,int length)
        {
            if (sum == 0) {
                return 1;// {} is the only subset
            }
            else if (sum < 0)
            {
                return 0;
            }
            else if (length < 0)
            {
                return 0;
            }
            else if (sum<arr[length]) // When the sum is less the current array element then there is no way we can get a total of given sum from current subarray
            {
                return FindSubSet(arr, sum, length - 1);
            }
            else
            {
                return FindSubSet(arr, sum - arr[length], length - 1) + FindSubSet(arr, sum, length - 1);
            }            
        }
        public static int FindSubSetIterative(int[] arr,int sum)
        {
            if (arr.Length == 0) { return 0; }
            else if (sum < 0) { return 0; }
            else if (sum == 0) { return 1; }
            else
            {
                int sumTill = 0;
                int count = 0;
                for(int i = 0; i < arr.Length; i++)
                {
                    for(int j = 0; j < arr.Length; j++)
                    {
                        sumTill += arr[j];
                        if (sumTill < sum)
                        {
                            continue;
                        }
                        else if(sumTill>sum)
                        {
                            sumTill -= arr[j];
                        }
                    }
                }
            }
            return 0;
        }

        public static int FindSubSetDP(int[] arr,int sum,int length,Dictionary<string,int> mem)
        {
            string key = sum + ":" + length;
            int result;
            if (mem.ContainsKey(key))
            {                
                return mem[key];
            }
            if (sum == 0)
            {
                return 1;// {} is the only subset
            }
            else if (sum < 0)
            {
                return 0;
            }
            else if (length < 0)
            {
                return 0;
            }
            else if (sum < arr[length]) // When the sum is less the current array element then there is no way we can get a total of given sum from current subarray
            {
                result = FindSubSetDP(arr, sum, length - 1,mem);
            }
            else
            {
                result = FindSubSetDP(arr, sum - arr[length], length - 1,mem) + FindSubSetDP(arr, sum, length - 1,mem);
            }
            mem[key] = result;
            return result;
        }
    }
}
