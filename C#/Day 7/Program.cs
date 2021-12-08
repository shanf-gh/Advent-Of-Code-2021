using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day_7
{
    class Program
    {
        static void Main(string[] args)
        {
            // string inputFile = "input-sample.txt";
            string inputFile = "input.txt";
            int[] crabPositions = Array.ConvertAll(File.ReadLines(inputFile).First().Split(','), s => int.Parse(s));
            
            Console.WriteLine("Part 1 - Constant consumption: {0}", calculateFuelConsumption(crabPositions, getMedian(crabPositions), true));
            Console.WriteLine("Part 2 - increasing consumption: {0}", calculateFuelConsumption(crabPositions, getMedian(crabPositions), false));
            
        }

        private static decimal getMedian(int[] values) {

            // create tempArray and count number of values
            int[] tempArray = values;
            int count = tempArray.Length;

            // sort array
            Array.Sort(tempArray);

            decimal median = -1;
            
            if(count % 2 == 0) {
                // count if even, need to get middle 2 elements and calculate half of their sum
                int middleElement1 = tempArray[(count/2)- 1];
                int middleElement2 = tempArray[(count/2)];
                median = (middleElement1 + middleElement2)/ 2;
                
            } else {
                // count is odd, get the middle element
                median = tempArray[(count/2)];
            }
            // Console.WriteLine(median);
            return median;
        }

        private static int calculateFuelConsumption(int[] crabPos, decimal median, Boolean constantConsumption) {
            int fuelConsumption = 0;
            int medianInt = decimal.ToInt32(median);
            int avgInt = (int)Math.Floor(crabPos.Average());
            
            foreach(int crab in crabPos) {

                if(constantConsumption) {
                    // constant consumption - consumption equal nbr moves
                    fuelConsumption += Math.Abs(crab - medianInt);
                } else {
                    // if consumption is not constant calculate the consumption;
                    int crabConsumption = 0;
                    for(int i = 1; i <= Math.Abs(crab - avgInt); i++) {
                        crabConsumption += i;
                    } 
                    fuelConsumption += crabConsumption;
                }

                // Console.WriteLine("Current crab position: {0}; {}; {}", crab, crab - medianInt);
            }

            return fuelConsumption;
        }
    }
}
