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
            Console.WriteLine("Finding nth Fibonacci no :");
            DateTime startTime, endTime;
            // Calling recursive method
            Console.Write("Recursive : Enter the value of n -");
            int n = Convert.ToInt32(Console.ReadLine());
            startTime = DateTime.Now;
            //int result = FibonaciSeries(n);
            //Console.WriteLine("Result - "+result);
            endTime = DateTime.Now;
            Console.WriteLine("Time Taken - "+(endTime-startTime));

            // Calling Iterative method
            Console.Write("Iterative : Enter the value of n -");
            n = Convert.ToInt32(Console.ReadLine());
            startTime = DateTime.Now;
            //int itResult = FibonaciSeriesIterative(n);
            //Console.WriteLine("Result - " + itResult);
            endTime = DateTime.Now;
            Console.WriteLine("Time Taken - " + (endTime - startTime));

            // Calling FibbonaciMemoize
            // Taking memo with size 1 greater than n to handle zero
            Console.Write("Memoization : Enter the value of n -");
            n = Convert.ToInt32(Console.ReadLine());
            startTime = DateTime.Now;
            int[] memo = new int[n + 1];            
            int memRes = FibonacciMemoize(n, memo);
            Console.WriteLine("Result - " + memRes);
            endTime = DateTime.Now;
            Console.WriteLine("Time Taken - " + (endTime - startTime));

            Console.Write("Bottomup Approach : Enter the value of n -");
            n = Convert.ToInt32(Console.ReadLine());
            startTime = DateTime.Now;           
            int bottomUpRes = FibonacciMemoizationIterative(n);
            Console.WriteLine("Result - " + bottomUpRes);
            endTime = DateTime.Now;
            Console.WriteLine("Time Taken - " + (endTime - startTime));
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

        #region Buttom Up Approch
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
        #endregion  
    }
}
