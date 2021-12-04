using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] input = System.IO.File.ReadAllLines("input.txt");

            int[] zeroCount = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] oneCount = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            foreach(string value in input) {
                string[] values = value.Split("");

                for (int i = 0; i < value.Length; i++) {
                    if(value[i]=='1') {
                        oneCount[i] += 1;
                    } else {
                        zeroCount[i] += 1;
                    }
                }
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

            // Step 2 - Life support rating

            // Oxygen generator rating
            // determine most common binary and split them into different lists
            List<String> inputList = input.ToList<String>();
            int oxygenGeneratorRating = Convert.ToInt32(reduce(inputList, 0, "most")[0],2);
            int CO2ScrubberRating =  Convert.ToInt32(reduce(inputList, 0, "least")[0],2);
            int lifeSupportRating = oxygenGeneratorRating * CO2ScrubberRating;

            Console.WriteLine($"oxygenGeneratorRating is: {oxygenGeneratorRating}");
            Console.WriteLine($"CO2ScrubberRating is: {CO2ScrubberRating}");
            Console.WriteLine($"Life support rating is: {lifeSupportRating}");

        }

        static List<string> reduce(List<String> currInput, int depth, string type) {
            List<string> currZero =  new List<string>();
            List<string> currOne = new List<string>();
            int zeroCount = 0;
            int oneCount = 0;
			Boolean useOneList = true;
		
			if(currInput.Count == 1) {
				// Console.WriteLine("stopped at depth: " + depth);
				return currInput;
			}

            foreach(string value in currInput) {
                char[] values = value.ToCharArray();

                if(values[depth]=='0') {
                    currZero.Add(value);
                    zeroCount += 1;
                }

                if(values[depth]=='1') {
                    currOne.Add(value);
                    oneCount += 1;
                }
            }
		
			if(type == "most") {
				useOneList = zeroCount <= oneCount;
			} else if (type == "least") {
				useOneList = zeroCount > oneCount;
			}	

            if(useOneList) {
                return reduce(currOne, depth+1, type);
            } else {
                return reduce(currZero, depth+1, type);
            }		
        }
    }
}
