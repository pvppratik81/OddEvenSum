using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddEvenSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string lines = @"215
                            192 124
                            117 269 442
                            218 836 347 235
                            320 805 522 417 345
                            229 601 728 835 133 124
                            248 202 277 433 207 263 257
                            359 464 504 528 516 716 871 182
                            461 441 426 656 863 560 380 171 923
                            381 348 573 533 448 632 387 176 975 449
                            223 711 445 645 245 543 931 532 937 541 444
                            330 131 333 928 376 733 017 778 839 168 197 197
                            131 171 522 137 217 224 291 413 528 520 227 229 928
                            223 626 034 683 839 052 627 310 713 999 629 817 410 121
                            924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";
            //string lines = @"1
            //                8 9
            //                1 5 9
            //                4 5 2 3";

            var charArray = lines.Split('\n');
            var numbers = new int[charArray.Length][];
            for (int i = 0; i < charArray.Length; i++)
            {
                numbers[i] = Array.ConvertAll(charArray[i].Trim().Split(' '), int.Parse);
            }
            int max = GetMaximumSum(numbers);
            Console.WriteLine(max);
            Console.ReadKey();
        }

        static int GetMaximumSum(int[][] numbers)
        {
            int sumOddEven = numbers[0][0];
            bool isNextPickNumberEven = true;
            int startSequence = 0;
            if (numbers[0][0] % 2 == 0)
            {
                isNextPickNumberEven = false;
            }
            for (int i = 1; i < numbers.Length; i++)
            {
                if (isNextPickNumberEven)
                {
                    int firstChild = numbers[i][startSequence] % 2 == 0 ? numbers[i][startSequence] : 0;
                    int secondChild = numbers[i][startSequence + 1] % 2 == 0 ? numbers[i][startSequence + 1] : 0;                     
                    sumOddEven += Math.Max(firstChild, secondChild);
                    if (secondChild > firstChild)
                    {
                        startSequence++;
                    }
                    isNextPickNumberEven = false;
                }
                else
                {
                    int firstChild = numbers[i][startSequence] % 2 != 0 ? numbers[i][startSequence] : 0;
                    int secondChild = numbers[i][startSequence + 1] % 2 != 0 ? numbers[i][startSequence + 1] : 0;
                    sumOddEven += Math.Max(firstChild, secondChild);
                    if (secondChild > firstChild)
                    {
                        startSequence++;
                    }
                    isNextPickNumberEven = true;
                }
            }

            return sumOddEven;
        }
    }
}
