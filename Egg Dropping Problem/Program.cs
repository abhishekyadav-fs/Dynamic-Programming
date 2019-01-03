using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EggDroppingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no of floors");
            int floors = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter no of eggs");
            int eggs = Convert.ToInt32(Console.ReadLine());
            int?[,] memo = new int?[floors + 1, eggs + 1];
            int res = EggDropping(floors, eggs, memo);
            Console.WriteLine("Result" + res);
            Console.ReadKey();
        }

        public static int EggDropping(int floors, int eggs, int?[,] memo)
        {
            // If there is only one floor or there is no floor then we need floors number of trail
            if (floors == 1 || floors == 0)
            {
                memo[floors, eggs] = floors;
                return floors;
            }
            // If there is only one egg then we have to try from each floor
            if (eggs == 1)
            {
                memo[floors, eggs] = floors;
                return floors;
            }
            if (memo[floors, eggs] != null)
            {
                return (int)memo[floors, eggs];
            }
            int min = int.MaxValue;

            // Check from each floor with all eggs
            for (int i = 1; i <= floors; i++)
            {
                // First if egg breaks from ith flooee then we have
                int res = 1 + Max(EggDropping(i - 1, eggs - 1,memo), EggDropping(floors - i, eggs,memo));
                if (res < min)
                {
                    min = res;
                }
                memo[floors, eggs] = min;
            }            
            return min;
            
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
