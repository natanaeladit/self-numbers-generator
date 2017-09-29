using System;
using System.Collections.Generic;
using System.Linq;

namespace selftnumber
{
    class Program
    {
        /// <summary>
        /// Func D(n) = n plus the sum of the digits of n
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>number</returns>
        static int FuncD(int n)
        {
            int retVal = 0;
            if (n > 0)
            {
                int nDigit = (int)Math.Floor(Math.Log10(n) + 1);
                string nStr = n.ToString();
                retVal = n;
                foreach (char c in nStr.ToArray())
                {
                    int number = (int)Char.GetNumericValue(c);
                    retVal = retVal + number;
                }
            }
            return retVal;
        }

        /// <summary>
        /// Check whether a given number is a self-number or not
        /// </summary>
        /// <param name="n">number</param>
        /// <returns>True or False</returns>
        static bool IsSelfNumber(int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                int number = FuncD(i);
                if (number == n)
                {
                    count++;
                }
            }
            return count > 0 ? false : true;
        }

        /// <summary>
        /// Find self-numbers within a range of two integers. Bigger than low index and smaller than high index.
        /// </summary>
        /// <param name="lIdx">low index</param>
        /// <param name="hIdx">high index</param>
        /// <returns>A list of self-numbers</returns>
        static List<int> FindSelfNumbers(int lIdx, int hIdx)
        {
            List<int> retVal = new List<int>();
            for (int i = lIdx + 1; i < hIdx; i++)
            {
                if (IsSelfNumber(i))
                {
                    retVal.Add(i);
                }
            }
            return retVal;
        }

        /// <summary>
        /// Sum all integers in an array
        /// </summary>
        /// <param name="arr">array of integers</param>
        /// <returns>sum</returns>
        static long Sum(List<int> arr)
        {
            long retVal = 0;
            foreach (int number in arr)
            {
                retVal = retVal + number;
            }
            return retVal;
        }

        static void Main(string[] args)
        {
            int lIdx = 0;
            int hIdx = 5000;

            Console.WriteLine("sum of all self-numbers which are bigger than " + lIdx + " and smaller than " + hIdx + ":");
            long sum = Sum(FindSelfNumbers(lIdx, hIdx));
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
