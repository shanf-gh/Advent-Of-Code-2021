using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_8
{
    class Program
    {
    
        static void Main(string[] args)
        {
            // part 1
            int solutionSamplePart1 = solutionOne("input-sample.txt");
            int solutionPart1 = solutionOne("input.txt");

            Console.WriteLine("The sample solution is {0}", solutionSamplePart1);
            Console.WriteLine("The Part one solution is {0}", solutionPart1);

            // part 2
            int solutionSamplePart2 = solutionTwo("input-sample.txt");
            // int solutionPart2 = solutionTwo("input.txt");

            Console.WriteLine("The sample solution is {0}", solutionSamplePart2);
            // Console.WriteLine("The Part one solution is {0}", solutionPart2);
        }

        private static int solutionOne(string filename) {
            int[] uniqueLength = {2, 3, 4, 7};
            int count = 0;

            List<string[]>[] input = readfile(filename); 
            // Solution one only requires the output digits to be analysed
            List<string[]> outputDigits = input[1];

            // create a segment map
            for(int i = 0; i < outputDigits.Count; i++) {
                // count patterns that are 1, 4, 7 or 8
                foreach(string output in outputDigits[i]) {
                    count += uniqueLength.Contains(output.Length) ? 1 : 0;
                }
            }
            

            return count;
        }
        private static int solutionTwo(string filename) {
            int value = 0;

            
            var correctMap = new Dictionary<string, int>() {
                { "abcefg", 0 },
                { "cf", 1 },
                { "acdeg", 2 },
                { "acdfg", 3 },
                { "bcdf", 4 },
                { "abdfg", 5 },
                { "abdefg", 6 },
                { "acf", 7 },
                { "abcdefg", 8 },
                { "abcdfg", 9 },
            };

            List<string[]>[] input = readfile(filename); 
            List<string[]> signalPatterns = input[0];
            List<string[]> outputDigits = input[1];
            List<int> outputDecoded = new List<int>();

            // Dictionary<char, char> segmentMap = patternAnalysis(signalPatterns[0]);
            // Console.WriteLine("Current signal pattern: {0}", string.Join(",", signalPatterns[0]));
            // foreach(var item in segmentMap) {
            //     Console.WriteLine("{0}: {1}", item.Key, item.Value);
            // }
            // Console.WriteLine(outputDigits[0][0].Select(c => segmentMap[c]).OrderBy(c => c).ToArray());

            // foreach(var digits in outputDigits) {
            //     Console.WriteLine("Current output digit: {0}", string.Join(",", digits));
            //     var plain = digits.Select(digit => new string(digit.Select(c => segmentMap[c]).OrderBy(c => c).ToArray()));
            //     Console.WriteLine("Current output digit: {0}", string.Join(",", plain));
            //     // outputDecoded.AddRange();
            // }

            for(int i = 0; i < signalPatterns.Count; i++) {
                // Console.WriteLine("{0}: {1} || {2}", i, string.Join(", ", signalPatterns[i]), string.Join(", ", outputDigits[i]));
                // create a segment map
                Dictionary<char, char> segmentMap = patternAnalysis(signalPatterns[i]);
                // interpret 4 digits with segment map
                // var plain = outputDigits[i].Select(digits => digits.Select(digit => new string(digit.Select(c => segmentMap[c]).OrderBy(c => c).ToArray())));
                var plain = outputDigits[i].Select(digits => new string(digits.Select(c => segmentMap[c]).OrderBy(c => c).ToArray()));
                // var plain = outputDigits.Select(ciphers => ciphers.Select(cipherText => new string(cipherText.Select(c => segmentMap[c]).OrderBy(c => c).ToArray())));
                outputDecoded.AddRange(plain.Select(mask => correctMap[mask]));
            }
            
            // Console.WriteLine(outputDecoded);
            // var hard = displays.Select(x => int.Parse(string.Join("", x.decoded.Select(digit => digit.ToString())))).Sum();
            
            Console.WriteLine(outputDecoded[0]);
            Console.WriteLine(outputDecoded[1]);
            Console.WriteLine(outputDecoded[2]);
            Console.WriteLine(outputDecoded[3]);
            // foreach(var output in outputDecoded) {
            //     Console.WriteLine(outputDecoded[]);
            // }
            value = outputDecoded.Select(x => ).Sum();
            // value = outputDecoded.Select(x => int.Parse(string.Join("", x.Select(digit => digit.ToString())))).Sum();

            // count numbers

            return value;
        }
        private static List<string[]>[] readfile(string filename) {
            
            // read input into array
            String[] input = System.IO.File.ReadAllLines(filename);

            // split input array into two lists
            // 10 signal parterns and the 4 output digits
            List<string[]> signalPatterns = new List<string[]>();
            List<string[]> outputDigits = new List<string[]>();

            foreach(string line in input) {
                string[] lineSplit = line.Split("|");
                
                string[] invidivualSignalPatterns = lineSplit[0].Split(" ");
                string[] invidivualOutputDigits = lineSplit[1].Trim().Split(" ");

                signalPatterns.Add(invidivualSignalPatterns);
                outputDigits.Add(invidivualOutputDigits);
            }

            List<string[]>[] inputLists = new List<string[]>[] {signalPatterns, outputDigits};
            return inputLists;
        }

        private static Dictionary<char, char> patternAnalysis(string[] input) {
            var chars = "abcdefg".ToArray();

            var d1 = input.Where(i => i.Length == 2).First();
            var d4 = input.Where(i => i.Length == 4).First();
            var d7 = input.Where(i => i.Length == 3).First();

            var map = new Dictionary<char, char>();
            var a = d7.Except(d1);
            map[a.First()] = 'a';
            var b = chars.Where(c => input.Count(i => i.Contains(c)) == 6);
            map[b.First()] = 'b';
            map[chars.Where(c => input.Count(i => i.Contains(c)) == 8).Except(a).First()] = 'c';
            var d = d4.Except(d1).Except(b);
            map[d.First()] = 'd';
            map[chars.Where(c => input.Count(i => i.Contains(c)) == 4).First()] = 'e';
            map[chars.Where(c => input.Count(i => i.Contains(c)) == 9).First()] = 'f';
            map[chars.Where(c => input.Count(i => i.Contains(c)) == 7).Except(d).First()] = 'g';

            return map;   
        }
    }
}
