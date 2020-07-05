﻿using System;
using System.Collections.Generic;

namespace assignment_1_group_1
{
    class Program
    {
        static bool ContainsDuplicate(char[] arr, int k)
        {
            // instantiate dictionary
            Dictionary<char, int> data = new Dictionary<char, int>();
            // for loop is O(n)
            for (var i = 0; i < arr.Length; i++)
            {
                // try to add current char as key. set value to current index
                bool added = data.TryAdd(arr[i], i);
                // if current char wasn't added, check current array index against
                // the value in the dictionary (i.e. previously seen)
                if (!added)
                {
                    // first index value
                    int firstVal = data[arr[i]];
                    // current (i.e. second) index value
                    int secondVal = i;
                    // take absolute difference
                    int absVal = Math.Abs(firstVal - secondVal);
                    // check absVal is at most equal to k (i.e. <=)
                    if (absVal <= k)
                    {
                        return true;
                    }
                    // set new value of latest index if conditional check fails
                    // in case the result appears again (e.g. [k, a, k, k])
                    data[arr[i]] = i;
                }
            }

            return false;
        }
        static void Main(string[] args)
        {
            // QUESTION 6
            // Example 1
            char[] input = new char[] { 'a', 'g', 'h', 'a' };
            int target = 3;
            bool result = ContainsDuplicate(input, target);
            Console.WriteLine("Question 6 Example 1: {0}", result);
            // Example 2
            char[] input2 = new char[] { 'k', 'y', 'k', 'k' };
            int target2 = 1;
            bool result2 = ContainsDuplicate(input2, target2);
            Console.WriteLine("Question 6 Example 2: {0}", result2);
            // Example 3
            char[] input3 = new char[] { 'a', 'b', 'c', 'a', 'b', 'c' };
            int target3 = 2;
            bool result3 = ContainsDuplicate(input3, target3);
            Console.WriteLine("Question 6 Example 3: {0}", result3);
        }
    }
}
