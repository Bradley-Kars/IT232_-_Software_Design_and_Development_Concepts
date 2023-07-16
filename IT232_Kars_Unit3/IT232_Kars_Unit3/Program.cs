using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        string[,] salesRegions = new string[,]
        {
            {"North", "South", "East", "West"},
            {"Bob", "Sue", "Nathan", "Wanda"},
            {"Stef", "Janice", "Henry", "Charles"},
            {"Ron", "Will", "Kimmy", "Pete"}
        };

        // Displaying the contents of the two-dimensional array
        Console.WriteLine("Section 1: Two-dimensional Array.");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(salesRegions[0, i]);
            for (int j = 1; j < 4; j++)
            {
                Console.WriteLine(salesRegions[j, i]);
            }
            Console.WriteLine();
        }

        ArrayList salesTeam = new ArrayList();

        // Adding names from the North region to the salesTeam ArrayList
        for (int i = 1; i < 4; i++)
        {
            salesTeam.Add(salesRegions[i, 0]);
        }

        Console.WriteLine("\nSection 2: ArrayList.");
        Console.WriteLine("There are " + salesTeam.Count + " names in the salesTeam ArrayList.");

        // Adding names from the South region to the salesTeam ArrayList
        for (int i = 1; i < 4; i++)
        {
            salesTeam.Add(salesRegions[i, 1]);
        }

        if (salesTeam.Contains("Stef"))
        {
            Console.WriteLine("Stef is in the salesTeam ArrayList.");
        }
        else
        {
            Console.WriteLine("Stef is not in the salesTeam ArrayList.");
        }

        Console.WriteLine("There are " + salesTeam.Count + " names in the salesTeam ArrayList.");

        // Removing "Janice" and "Ron" from the salesTeam ArrayList
        salesTeam.Remove("Janice");
        salesTeam.Remove("Ron");

        Console.WriteLine("There are " + salesTeam.Count + " names in the salesTeam ArrayList.");

        Console.WriteLine("\nNames currently in the salesTeam ArrayList:");
        foreach (string name in salesTeam)
        {
            Console.WriteLine(name);
        }

        // Keep the terminal open until user input
        Console.ReadLine();
    }
}
