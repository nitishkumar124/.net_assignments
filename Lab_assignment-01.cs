using System;
using System.Collections.Generic;

namespace LabAssignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TransactionsSum();
            ScoreAverage();
            ExpensiveItem();
            GenderParticipantsCount();
            ReverseSearchHistory();
            AdjustMeasurements();
            SearchBookCode();
            FindSecondSmallestGrade();
            RemoveDuplicateIDs();
            FindCommonElements();
        }

        // Question 1
        static void TransactionsSum()
        {
            int[] transactions = { 200, -150, 340, 500, -100 };
            int total = 0;
            Array.ForEach(transactions, t => total += t);

            Console.WriteLine($"Total Sum: {total}");
        }

        // Question 2
        static void ScoreAverage()
        {
            float[] scores = { 85.5f, 90.3f, 78.4f, 88.9f, 92.1f };
            float total = 0;
            for (int i = 0; i < scores.Length; i++)
                total += scores[i];

            Console.WriteLine($"Average Score: {total / scores.Length}");
        }

        // Question 3
        static void ExpensiveItem()
        {
            int[] prices = { 1500, 2300, 999, 3200, 1750 };
            int costliest = prices[0];
            for (int i = 1; i < prices.Length; i++)
                if (prices[i] > costliest)
                    costliest = prices[i];

            Console.WriteLine($"Most Expensive Item: {costliest}");
        }

        // Question 4
        static void GenderParticipantsCount()
        {
            int[] codes = { 102, 215, 324, 453, 536 };
            int maleCount = 0, femaleCount = 0;

            foreach (var code in codes)
                if (code % 2 == 0) maleCount++;
                else femaleCount++;

            Console.WriteLine($"Males: {maleCount}, Females: {femaleCount}");
        }

        // Question 5
        static void ReverseSearchHistory()
        {
            int[] history = { 101, 202, 303, 404, 505 };
            Array.Reverse(history);
            Console.WriteLine("Reversed Search History: " + string.Join(" ", history));
        }

        // Question 6
        static void AdjustMeasurements()
        {
            int[] measures = { 2, 4, 6, 8 };
            int multiplier = 3;

            for (int i = 0; i < measures.Length; i++)
                measures[i] *= multiplier;

            Console.WriteLine("Adjusted Measurements: " + string.Join(" ", measures));
        }

        // Question 7
        static void SearchBookCode()
        {
            int[] codes = { 101, 203, 304, 405, 506 };
            int searchFor = 304;

            int position = Array.IndexOf(codes, searchFor);
            Console.WriteLine(position >= 0
                ? $"Book found at index: {position}"
                : "Book not found.");
        }

        // Question 8
        static void FindSecondSmallestGrade()
        {
            int[] grades = { 56, 78, 89, 45, 67 };
            Array.Sort(grades);

            Console.WriteLine($"Second Smallest Grade: {grades[1]}");
        }

        // Question 9
        static void RemoveDuplicateIDs()
        {
            int[] ids = { 102, 215, 102, 324, 215 };
            HashSet<int> uniqueIds = new HashSet<int>(ids);

            Console.WriteLine("Unique IDs: " + string.Join(", ", uniqueIds));
        }

        // Question 10
        static void FindCommonElements()
        {
            int[] set1 = { 1, 2, 3, 4, 5 };
            int[] set2 = { 3, 4, 5, 6, 7 };

            List<int> common = new List<int>();
            foreach (var x in set1)
                if (Array.Exists(set2, y => y == x) && !common.Contains(x))
                    common.Add(x);

            Console.WriteLine("Common Elements: " + string.Join(", ", common));
        }
    }
}
