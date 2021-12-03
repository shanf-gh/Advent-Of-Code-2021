using System;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = System.IO.File.ReadAllLines("input.txt");

            int[] zeroCount = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] oneCount = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int j = 0;

            foreach(string value in input) {
                string[] values = value.Split("");

                for (int i = 0; i < value.Length; i++) {
                    if(value[i]=='1') {
                        oneCount[i] += 1;
                    } else {
                        zeroCount[i] += 1;
                    }
                }
                // Console.WriteLine($"value: {value}");

                // if(j>5) {
                //     break;
                // }
                // j++;
            }

            // Determine gamma and epsilon rates
            string gammaRate = "";
            string epsilonRate = "";

            for(int i=0; i < zeroCount.Length; i++) {
               if(zeroCount[i] > oneCount[i]) {
                   gammaRate += "0";
                   epsilonRate += "1";
               } else {
                   gammaRate += "1";
                   epsilonRate += "0";
               }
            }


            // convert binary rates to int
            int gammaRateDec = Convert.ToInt32(gammaRate, 2);
            int epsiloneRateDec = Convert.ToInt32(epsilonRate, 2);

            // calculate power consumption
            int powerConsumption = gammaRateDec * epsiloneRateDec;

            Console.WriteLine($"Power consumption is: {powerConsumption}");
                //  Console.WriteLine("[{0}]", string.Join(", ", zeroCount));
                //  Console.WriteLine("[{0}]", string.Join(", ", oneCount));
        }
    }
}
