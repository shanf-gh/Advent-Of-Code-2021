using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_6
{
    class Program
    {
        static void Main(string[] args)
        {            
            // Create an array of lenght 8 to keep track of count for each age
            long[] fishCount = {0, 0, 0, 0, 0, 0, 0, 0, 0};

            // read file -- assuming one line
            // string inputFile = "input-sample.txt";
            string inputFile = "input.txt";
            String[] input = System.IO.File.ReadAllLines(inputFile)[0].Split(",");
        
            foreach(string fish in input) {
                // convert string to int
                int fishAge = Convert.ToInt32(fish);

                // increment the index/fish age by one
                fishCount[fishAge] += 1;
            }
 
            int days = 256;

            for(int i = 1; i <= days; i++) {
                long newFishes = fishCount[0];
                // Console.WriteLine($"Day: {i}; New fishes: {newFishes}");
                // Console.WriteLine(fishCount.Length);
                // shift count per age
                for(int j = 0; j < fishCount.Length - 1; j++) {
                    fishCount[j] = fishCount[j+1];
                    // Console.WriteLine("Day: {0}; Age: {1}; CurrCount: {2}; NewCount: {3}",i, j, fishCount[j],  fishCount[j+1]);
                }
                // add new fishes to age 6 and 8
                fishCount[6] += newFishes; 
                fishCount[8] = newFishes; 
                // Console.WriteLine("Day: {0}; New fishes: {1}", i, string.Join(", ", fishCount));
                if(i == 80) {
                    Console.WriteLine("There are [{0}] fishes after [{1}] days.", fishCount.Sum(), i);
                }
            }
            Console.WriteLine("[{0}]", string.Join(", ", fishCount));
            Console.WriteLine("There are [{0}] fishes after [{1}] days.", fishCount.Sum(), days);
        }
    }
}
