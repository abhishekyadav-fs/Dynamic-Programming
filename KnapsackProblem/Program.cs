using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanpsack_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Values with weights
            int[] v = new int[] { 10, 40, 30, 50 };
            int[] w = new int[] { 5, 4, 6, 3 };
            // Maximun weight of the sack
            int maxWeight = 10;
            // The result will be 90 (4 Kg with 40, 3Kg with 50)
            int res = BruteForceApprochRecursion(v, w, maxWeight,w.Length-1);
            Console.WriteLine("Res-"+ res);
            int?[,] memo = new int?[w.Length, maxWeight];
            res = DynamicKanpsack(v, w, maxWeight, w.Length - 1,memo);
            Console.WriteLine("Res Dynamic-" + res);
            
            Console.ReadKey();
        }

        /// <summary>
        /// Knaspsack problem with recusion 
        /// </summary>
        /// <param name="v">value array</param>
        /// <param name="w">weight array</param>
        /// <param name="capacity">Maximum weight</param>
        /// <param name="n"> No of weights</param>
        /// <returns result="result">Maximum value that can be carried out  </returns>
        public static int BruteForceApprochRecursion(int[] v,int[] w,int capacity,int n)
        {
            int result;
            // Base case condition. If we dont have an weights so we cant choose any values. 
            //Or if maximum capacity is 0 in that case
            // We cant consider any of the weights. Hence return 0.
            if (n == 0|| capacity==0) { result = 0; }
            // If weight at current position is greater rhan the capacity, we moved to next weight
            else if(w[n]>capacity){ result = BruteForceApprochRecursion(v, w, capacity, n - 1); }
            else
            {
                // Yes condition, when we are considering the weight.
                //Then we are subtracting the weight from the maximum capacity.And summing up the value with our result.
                int yesValues = v[n] + BruteForceApprochRecursion(v, w, capacity - w[n], n - 1);
                // No condition, when we are not considering the weight. Hence moving to the next wight.
                int noValues = BruteForceApprochRecursion(v, w, capacity, n - 1);
                // Finally result is maximum of yes and no values
                if (yesValues > noValues) { result = yesValues; }
                else { result = noValues; }
                
            }
            return result;
        }

        /// <summary>
        /// Memoized solution of knapsacp problem
        /// </summary>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <param name="capacity"></param>
        /// <param name="n"></param>
        /// <param name="memo"></param>
        /// <returns></returns>
        public static int DynamicKanpsack(int[] v, int[] w, int capacity, int n,int?[,] memo)
        {
            int result;
            // Base case condition. If we dont have an weights so we cant choose any values. 
            //Or if maximum capacity is 0 in that case
            // We cant consider any of the weights. Hence return 0.
            if (capacity>0 && memo[n, capacity-1] !=null) { return (int)memo[n, capacity-1]; }
            else if(capacity <= 0 && memo[n, capacity] != 0) { return (int)memo[n, capacity]; }
            if (n == 0 || capacity == 0) { result = 0; }
            // If weight at current position is greater rhan the capacity, we moved to next weight
            else if (w[n] > capacity) { result = DynamicKanpsack(v, w, capacity, n - 1,memo); }
            else
            {
                // Yes condition, when we are considering the weight.
                //Then we are subtracting the weight from the maximum capacity.And summing up the value with our result.
                int yesValues = v[n] + DynamicKanpsack(v, w, capacity - w[n], n - 1,memo);
                // No condition, when we are not considering the weight. Hence moving to the next wight.
                int noValues = DynamicKanpsack(v, w, capacity, n - 1,memo);
                // Finally result is maximum of yes and no values
                if (yesValues > noValues) { result = yesValues; }
                else { result = noValues; }

            }
            if (capacity > 0) { memo[n, capacity - 1]=result; }
            else if (capacity <= 0 ) {memo[n, capacity] = result; }
            return result;
        }

        
    }
}
