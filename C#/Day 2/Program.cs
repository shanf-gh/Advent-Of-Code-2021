using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = System.IO.File.ReadAllLines("input.txt");

            int horizontalPos = 0;
            int verticalPos = 0;
            int aim = 0;
            int i = 0;

            foreach(string row in input){
                string[] rowData = row.Split(" ");
                int value = Convert.ToInt32(rowData[1]);

                switch(rowData[0]) {
                    case "forward":
                        horizontalPos += value;
                        verticalPos += aim * value;
                        break;
                    case "up":
                        // verticalPos -= value;
                        aim -= value;
                        break;
                    case "down":
                        // verticalPos += value;
                        aim += value;
                        break;
                }
            }
            Console.WriteLine($"Horizontal position is {horizontalPos} and vertical position is {verticalPos}.");
            Console.WriteLine($"The aim is {aim}");
            Console.WriteLine($"The product is {horizontalPos * verticalPos}");
        }
    }
}
