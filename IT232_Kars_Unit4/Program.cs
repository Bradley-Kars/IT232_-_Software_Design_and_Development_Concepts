using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace Unit4
{
    class Program
    {
        static void Main(string[] args)
        {
            //*********************************************************
            //****Assignment 4 Section 1
            //*********************************************************

            // Create an array of Car structures
            Car[] cars = new Car[]
            {
                new Car("Ford", "Mustang", 2010),
                new Car("Chevrolet", "Silverado", 2008),
                new Car("Dodge", "Charger", 2012)
            };

            // Print section title
            Console.WriteLine("Section 1: Array of Structures");

            // Display the full contents of each structure in the array
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }

            //*********************************************************
            //****Assignment 4 Section 2
            //*********************************************************

            // Create a dictionary for inventory count
            Dictionary<string, int> inventoryCount = new Dictionary<string, int>()
            {
                { "Mustang", 9 },
                { "Silverado", 13 },
                { "Charger", 4 }
            };

            // Print section title
            Console.WriteLine("\nSection 2: Inventory Count");

            // Display the current number of each model in the inventoryCount dictionary
            foreach (var item in inventoryCount)
            {
                Console.WriteLine($"There are {item.Value} {item.Key}s.");
            }

            //*********************************************************
            //****Assignment 4 Section 3
            //*********************************************************

            // Create an arraylist called DaysofWeek
            List<string> DaysofWeek = new List<string>()
            {
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            };

            // Print section title
            Console.WriteLine("\nSection 3: Days of the Week");

            // Display the days from the DaysofWeek arraylist
            foreach (var day in DaysofWeek)
            {
                Console.WriteLine(day);
            }

            // Display the days from the DaysofWeek arraylist in reverse order
            for (int i = DaysofWeek.Count - 1; i >= 0; i--)
            {
                Console.WriteLine(DaysofWeek[i]);
            }

            // Create a second arraylist called WorkDays and copy the DaysofWeek arraylist to it
            List<string> WorkDays = new List<string>(DaysofWeek);

            // Delete "Saturday" and "Sunday" from the WorkDays arraylist
            WorkDays.Remove("Saturday");
            WorkDays.Remove("Sunday");

            // Print the contents of WorkDays
            Console.WriteLine(string.Join(", ", WorkDays));

            //*********************************************************
            //****Assignment 4 Section 4
            //*********************************************************

            // Print section title
            Console.WriteLine("\nSection 4: Stack");

            // Create a stack
            Stack<int> stack = new Stack<int>();

            // Push values into the stack
            stack.Push(10);
            stack.Push(24);
            stack.Push(31);
            stack.Push(45);
            stack.Push(19);
            stack.Push(76);

            // Print a message telling how many items are on the stack
            Console.WriteLine($"There are {stack.Count} items in the stack.");

            // Pop three items off of the stack
            stack.Pop();
            stack.Pop();
            stack.Pop();

            // Print a message telling how many items are in the stack
            Console.WriteLine($"There are {stack.Count} items in the stack.");

            // Display the next item in the stack to be popped
            if (stack.Count > 0)
            {
                var nextItem = stack.Peek();
                Console.WriteLine($"The next item to be popped from the stack is {nextItem}.");
            }

            //*********************************************************
            //****Assignment 4 Section 5
            //*********************************************************

            // Print section title
            Console.WriteLine("\nSection 5: Queue");

            // Create a queue
            Queue<int> queue = new Queue<int>();

            // Enqueue values into the queue
            queue.Enqueue(10);
            queue.Enqueue(24);
            queue.Enqueue(31);
            queue.Enqueue(45);
            queue.Enqueue(19);
            queue.Enqueue(76);

            // Print a message telling how many items are on the queue
            Console.WriteLine($"There are {queue.Count} items in the queue.");

            // Dequeue three items from the queue
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            // Print a message telling how many items are in the queue
            Console.WriteLine($"There are {queue.Count} items in the queue.");

            // Display the next item in the queue to be dequeued
            if (queue.Count > 0)
            {
                var nextItem = queue.Peek();
                Console.WriteLine($"The next item to be dequeued from the queue is {nextItem}.");
            }

            Console.ReadLine();
        }
    }

    // Structure for Car
    struct Car
    {
        public string Make;
        public string Model;
        public int ModelYear;

        public Car(string make, string model, int modelYear)
        {
            Make = make;
            Model = model;
            ModelYear = modelYear;
        }

        public override string ToString()
        {
            return $"{Make}, {Model}, {ModelYear}";
        }
    }
}
