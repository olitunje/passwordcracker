using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write("Enter the target word or number: ");
        string target = Console.ReadLine();

        Console.WriteLine("Searching for the target...");

        // Set the character set that will be used for generating combinations
        string characterSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        bool found = false;

        // Loop through all possible combinations
        for (int length = 1; length <= target.Length; length++)
        {
            found = GenerateCombinations(characterSet.ToCharArray(), length, target);
            if (found)
                break;
        }

        if (found)
        {
            Console.WriteLine("Target found!");
        }
        else
        {
            Console.WriteLine("Target not found.");
        }

        Console.ResetColor();
    }

    static bool GenerateCombinations(char[] characterSet, int length, string target)
    {
        char[] combination = new char[length];
        bool found = false;
        GenerateCombinationsRecursive(characterSet, combination, 0, length, ref found, target);
        return found;
    }

    static void GenerateCombinationsRecursive(char[] characterSet, char[] combination, int position, int length, ref bool found, string target)
    {
        if (found)
            return;

        if (position == length)
        {
            string generated = new string(combination);

            // Check if the generated combination matches the target
            Console.WriteLine(generated);

            if (generated == target)
                found = true;

            return;
        }

        for (int i = 0; i < characterSet.Length; i++)
        {
            combination[position] = characterSet[i];
            GenerateCombinationsRecursive(characterSet, combination, position + 1, length, ref found, target);
        }
    }
}
