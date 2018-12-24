using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calling recursive method
            int result = FibonaciSeries(9);
            Console.WriteLine(result);
            // Calling Iterative method
            int itResult = FibonaciSeriesIterative(9);
            Console.WriteLine(itResult);
            // Calling FibbonaciMemoize
            // Taking memo with size 1 greater than n to handle zero
            int[] memo = new int[9 + 1];
            
            int memRes = FibonacciMemoize(9, memo);
            Console.WriteLine(memRes);

            Console.WriteLine(FibonacciMemoizationIterative(9));
            Console.ReadKey();
        }
        #region Recursive Fibonacci
        /// <summary>
        /// Recursion
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int FibonaciSeries(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return FibonaciSeries(n - 1) + FibonaciSeries(n - 2);
        }
        #endregion

        #region Iterative Fibonacci
        /// <summary>
        /// Iterative Fibonaci Number
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Nth Fibbonaci no</returns>
        public static int FibonaciSeriesIterative(int n)
        {
            int res = 0;
            int a = 0, b = 1;
            if (n == 0) { return 0; }
            if(n==1) { return 1; }
            for(int i = 2; i <= n; i++)
            {
                res = a + b;
                a = b;
                b = res;
            }
            return res;
        }
        #endregion

        #region Memoize Fibonacci 
        /// <summary>
        /// Recursive memoization
        /// </summary>
        /// <param name="n"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public static int FibonacciMemoize(int n,int[] memo)
        {
            int result = 0;
            if (memo[n] != 0)
            {
                return memo[n];
            }
            if (n == 1 || n==2)
            {
                result = 1;
                memo[n] = result;
                return result;              
            }
            result = FibonacciMemoize(n - 1,memo) + FibonacciMemoize(n - 2, memo);
            memo[n] = result;
            return result;
        }
        #endregion

        /// <summary>
        /// Iterative memoize implementation 
        /// </summary>
        /// <param name="n"></param>
        /// <returns Nth fibonacci number> </returns>
        public static int FibonacciMemoizationIterative(int n)
        {
            int[] result = new int[n + 2];
            result[0] = 0;
            result[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                result[i] = result[i - 1] + result[i - 2];
            }
            return result[n];
        }
    }
}
