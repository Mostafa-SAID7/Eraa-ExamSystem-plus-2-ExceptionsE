using System;

/// <summary>
/// Custom exception thrown when no vowels are found.
/// </summary>
public class NoVowelException : Exception
{
    public NoVowelException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a string:");
            string input = Console.ReadLine();

            CheckForVowels(input);

            Console.WriteLine("The string contains at least one vowel.");
        }
        catch (NoVowelException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    /// <summary>
    /// Checks if the input string contains any vowels. Throws NoVowelException if none are found.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    static void CheckForVowels(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input cannot be null or empty.");

        string vowels = "aeiouAEIOU";
        foreach (char c in input)
        {
            if (vowels.Contains(c))
                return;
        }

        throw new NoVowelException("The string does not contain any vowels.");
    }
}
