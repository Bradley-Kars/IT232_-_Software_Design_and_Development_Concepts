using System;
using System.Diagnostics;

namespace IT232_YourLastName_Unit6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 6 – Asserts and Try/Catch.");

            //*********************************************************
            //****Assignment 6 Section 1
            //*********************************************************

            // Create a string variable and set its value to null or empty
            string value = string.Empty;

            // Create an integer variable and set it to 0
            int number = 0;

            // Assert that the string variable is not empty or null
            Debug.Assert(!string.IsNullOrEmpty(value), "Parameter must not be empty or null.");

            // Assert that the integer variable is greater than zero
            Debug.Assert(number > 0, "Parameter must be greater than zero.");

            //*********************************************************
            //****Assignment 6 Section 2
            //*********************************************************

            // Array of strings
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };

            // Try to access an array element outside the bounds
            try
            {
                string someName;
                for (int i = 0; i <= names.Length; i++)
                {
                    someName = names[i];
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("ArrayOutOfBounds error occurred");
                Console.WriteLine(ex.Message);
            }

            //*********************************************************
            //****Assignment 6 Section 3
            //*********************************************************

            // Try to open a non-existent file
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader("C:\\NoFileNamedThis.txt"))
                {
                    // File reading code
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine("FileDoesNotExist error occurred");
                Console.WriteLine(ex.Message);
            }

            //*********************************************************
            //****Assignment 6 Section 4
            //*********************************************************

            // Call the DivideByZero function and handle the exception
            try
            {
                DivideByZero(42, 0);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("DivideByZero error occurred");
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        // Function that allows for two integer operands: dividend and divisor
        public static int DivideByZero(int dividend, int divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Divide By Zero");
            }

            return dividend / divisor;
        }
    }
}
