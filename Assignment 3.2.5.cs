/* Assignment 3.2.5
5. Create a function that finds the index of a given item in the array

Examples
Search([1, 5, 3], 5) ➞ 1
Search([9, 8, 3], 3) ➞ 2
Search([1, 2, 3], 4) ➞ -1

Notes
If the item is not present, return -1.
*/
public class Search
{
    public static void Main(string[] args)
    {
        int[] arr = { 1, 5, 3, 7, 9 };
        int itemToFind = GetUserInput<int>("Enter an integer to find its index in the array: ");
        int index = FindIndex(arr, itemToFind);
        PrintArray(arr);
        if (index != -1)
        {
            Console.WriteLine($"Item {itemToFind} found at index: {index}");
        }
        else
        {
            Console.WriteLine($"Item {itemToFind} not found in the array.");
        }
    }
    public static int FindIndex(int[] arr, int item)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == item)
            {
                return i; // Return the index if the item is found
            }
        }
        return -1; // Return -1 if the item is not found, why do we return -1?
    }
    public static void PrintArray(int[] arr)
    {
        Console.WriteLine("Array contents: [" + string.Join(", ", arr) + "]");
    }
    /// <summary> Prompts the user for input and ensures a non-empty string is returned. This is the non-generic overload.</summary>
    /// <param name="prompt">The message to display to the user.</param>
    /// <returns>A non-null, non-whitespace string from the user.</returns>
    private static string GetUserInput(string prompt)
    {
        string? input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
            }
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    /// <summary> Prompts the user for input, validates it, and converts it to the specified type `T`.
    /// See https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics for more details.
    /// </summary>
    /// <typeparam name="T">The desired type (e.g., int, decimal, double), which must be parsable.</typeparam>
    /// <param name="prompt">The message to display to the user.</param>
    /// <param name="parseErrorMessage">An optional custom error message to display on parsing failure.</param>
    /// <returns>A valid value of type `T` from the user.</returns>
    private static T GetUserInput<T>(string prompt, string? parseErrorMessage = null) where T : IParsable<T>
    {
        T? value;
        while (!T.TryParse(GetUserInput(prompt), null, out value)) // Calls GetUserInput() to get the raw user input first.
        {
            Console.WriteLine(parseErrorMessage ?? $"Invalid input. Please enter a valid {typeof(T).Name}.");
        }
        return value;
    }
}