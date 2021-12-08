using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read file
            String[] input = System.IO.File.ReadAllLines("input.txt");
            Dictionary<string, int> dicCoordinates = new Dictionary<string, int>();

            foreach(string line in input) {
                // split the coordinates
                int[] coordinates = line.Split(new string[] {"->", ","}, StringSplitOptions.RemoveEmptyEntries).Select(p => Int32.Parse(p.Trim())).ToArray();

                int x1 = coordinates[0];
                int y1 = coordinates[1];
                int x2 = coordinates[2];
                int y2 = coordinates[3];

                List<string> lineCoordinates = new List<string>();
                if(x1 == x2) {
                    // swap y if y2 is greater
                    if(y1 > y2) {
                        int temp = y1;
                        y1 = y2;
                        y2 = temp;
                    }

                    // get all coordinates between points
                    for(int i = y1; i <= y2; i++) {
                        lineCoordinates.Add($"{x1}, {i}");
                    }
                } else if (y1 == y2) {
                    // swap y if y2 is greater
                    if(x1 > x2) {
                        int temp = x1;
                        x1 = x2;
                        x2 = temp;
                    }
                    // get all coordinates between points
                    for(int i = x1; i <= x2; i++) {
                        lineCoordinates.Add($"{i}, {y1}");
                    }
                } else {
                    // Console.WriteLine($"calculating coordinates for {x1}, {y1} -> {x2}, {y2}");
                    int xIncrement = x1 < x2 ? 1 : -1; 
                    int yIncrement = y1 < y2 ? 1 : -1;

                    int xCoord = x1;
                    int yCoord = y1;
                    
                    lineCoordinates.Add($"{xCoord}, {yCoord}");
                    do {
                        xCoord += xIncrement;
                        yCoord += yIncrement;

                        // Console.WriteLine($"Adding currCoordinates: {xCoord}, {yCoord} (xinc:{xIncrement}, yinc:{yIncrement})");
                        
                        lineCoordinates.Add($"{xCoord}, {yCoord}");
                    } while (xCoord != x2 && yCoord != y2);
                }
                // Console.ReadLine();

                foreach(string currCoordinates in lineCoordinates) {

                    if(dicCoordinates.Keys.Contains(currCoordinates)) {
                        dicCoordinates[currCoordinates] += 1;
                    } else {
                        dicCoordinates.Add(currCoordinates, 1);
                    }
                }
            }

            int countTwoOrMore = dicCoordinates.Where(v => v.Value > 1).Count();

            Console.WriteLine(countTwoOrMore);
        }
    }
}
