using System;
using System.Collections;
using System.IO;

class Program
{
    static void Main()
    {
        //*********************************************************
        //****Assignment 5 Section 1
        //*********************************************************

        ArrayList produceList = new ArrayList();
        produceList.Add("bananas 0.59");
        produceList.Add("grapes 2.99");
        produceList.Add("apples 1.49");
        produceList.Add("pears 1.39");
        produceList.Add("lettuce 0.99");
        produceList.Add("onions 0.79");
        produceList.Add("potatoes 0.59");
        produceList.Add("peaches 1.59");

        WriteToFile("ProducePrice", produceList, false);

        int itemCount = FileLineCount("ProducePrice");
        Console.WriteLine("There are {0} products in the file.", itemCount);

        //*********************************************************
        //****Assignment 5 Section 2
        //*********************************************************

        ArrayList additionalProduce = new ArrayList();
        additionalProduce.Add("peppers 0.99");
        additionalProduce.Add("celery 1.29");
        additionalProduce.Add("cabbage 0.79");
        additionalProduce.Add("tomatoes 1.19");

        WriteToFile("ProducePrice", additionalProduce, true);

        itemCount = FileLineCount("ProducePrice");
        Console.WriteLine("There are {0} products in the file.", itemCount);

        //*********************************************************
        //****Assignment 5 Section 3
        //*********************************************************

        ArrayList producePrices = ReadFromFile("ProducePrice");
        itemCount = producePrices.Count;

        for (int i = 0; i < producePrices.Count; i++)
        {
            Console.WriteLine("{0} {1}", i + 1, producePrices[i]);
        }

        Console.WriteLine("There are {0} products in the producePrices list.", itemCount);

        Console.ReadKey(); // Wait for a key press before closing the terminal
    }

    static void WriteToFile(string fileName, ArrayList data, bool append)
    {
        using (StreamWriter writer = new StreamWriter(fileName + ".txt", append))
        {
            if (!append)
            {
                writer.Write(string.Empty); // Clear existing content if not appending
            }

            foreach (string item in data)
            {
                writer.WriteLine(item);
            }
        }
    }

    static ArrayList ReadFromFile(string fileName)
    {
        ArrayList data = new ArrayList();

        using (StreamReader reader = new StreamReader(fileName + ".txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                data.Add(line);
            }
        }

        return data;
    }

    static int FileLineCount(string fileName)
    {
        int count = 0;

        using (StreamReader reader = new StreamReader(fileName + ".txt"))
        {
            while (reader.ReadLine() != null)
            {
                count++;
            }
        }

        return count;
    }
}
