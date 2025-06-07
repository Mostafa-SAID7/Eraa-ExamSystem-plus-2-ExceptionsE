using System;
using System.Collections.Generic;

/// <summary>
/// Custom exception for duplicate numbers.
/// </summary>
public class DuplicateNumberException : Exception
{
    public DuplicateNumberException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a list of integers separated by spaces:");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = Array.ConvertAll(parts, int.Parse);

            CheckForDuplicates(numbers);

            Console.WriteLine("All numbers are unique.");
        }
        catch (DuplicateNumberException ex)
        {
            Console.WriteLine("Duplicate found: " + ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter only integers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }   

    /// <summary>
    /// Checks an integer array for duplicates and throws an exception if found.
    /// </summary>
    static void CheckForDuplicates(int[] numbers)
    {
        HashSet<int> seen = new HashSet<int>();
        foreach (int num in numbers)
        {
            if (!seen.Add(num))
            {
                throw new DuplicateNumberException($"The number {num} is duplicated.");
            }
        }
    }
}
