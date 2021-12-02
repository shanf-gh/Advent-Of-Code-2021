using System;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = System.IO.File.ReadAllLines("input.txt");
            
            int[] depth = new int[input.Length];
            for(int i=0; i < input.Length; i++) {
                depth[i] = Convert.ToInt32(input[i]);
            }

            int count = 0;

            for(int i=1; i < depth.Length; i++) {
                count += depth[i] - depth[i - 1] > 0 ? 1 : 0;
            }

            Console.WriteLine($"Solution 1: {count}");

            count = 0;

            for(int i=0; i < depth.Length -3; i++) {
                
                count += depth[i + 3] - depth[i] > 0 ? 1 : 0;
            }
            
            Console.WriteLine($"Solution 2: {count}");
        }
    }
}
