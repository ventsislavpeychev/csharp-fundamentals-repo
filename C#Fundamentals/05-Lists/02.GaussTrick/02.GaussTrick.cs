﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int originalCount = numbers.Count;
            
            for (int i = 0; i < originalCount / 2; i++)
            {
                numbers[i] += numbers[numbers.Count - 1];
                numbers.Remove(numbers[numbers.Count - 1]);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
