using System;
using System.Collections.Generic;

using static System.Math; 

namespace Lab_5
{
    class Program
    {
        public static void Main(string[] args)
        {
            var res = FindSubstrings("abacaba", "aba");
            Console.WriteLine(res);

            Console.ReadKey(true);
        }

        private static int[] ZFunction(string s)
        {
            int[] zf = new int[s.Length];

            int left = 0, right = 0;
            for (int i = 0; i < s.Length; i++)
            {
                zf[i] = Max(0, Min(right - i, zf[i - left]));

                while ((i + zf[i] < s.Length) && s[zf[i]] == s[i + zf[i]])
                {
                    zf[i]++;
                }

                if (i + zf[i] > right)
                {
                    left = i;
                    right = i + zf[i];
                }
            }
            return zf;
        }

        private static int FindSubstringFirst(string text, string pattern)
        {
            int[] zf = ZFunction(pattern + '#' + text);
            for (int i = pattern.Length + 1; i < text.Length + 2; i++)
            {
                if (zf[i] == pattern.Length)
                {
                    return i - pattern.Length - 1;
                }
            }
            return -1;
        }

        private static int FindSubstringLast(string text, string pattern)
        {
            int[] zf = ZFunction(pattern + '#' + text);
            for (int i = text.Length + 1; i >= pattern.Length + 1; i--)
            {
                if (zf[i] == pattern.Length)
                {
                    return i - pattern.Length - 1;
                }
            }
            return -1;
        }

        private static List<int> FindSubstrings(string text, string pattern)
        {
            var indexes = new List<int>();
            int[] zf = ZFunction(pattern + '#' + text);
            for (int i = pattern.Length + 1; i < text.Length + 2; i++)
            {
                if (zf[i] == pattern.Length)
                {
                    indexes.Add(i - pattern.Length - 1);
                }
            }
            return indexes;
        }

        private static int DifSubstringsCount(string str) 
        {


            return 0;
        }
    }
}