using System;
using System.IO;

namespace IT232_Kars_Unit7
{
    class Program
    {
        // Define logfile string variable
        static string logFileName;

        static void Main(string[] args)
        {
            Console.WriteLine("Assignment 7 – Logging Exceptions to a File.");
            Console.WriteLine("Testing Try/Catch for Divide by Zero, File Does Not Exist, Array Out of Bounds, and Array is Null scenarios.");
            Console.WriteLine("All further console error messages are printed from error log file");

            // Create logfile with an open stream
            logFileName = "log.txt";
            TextWriter errStream = new StreamWriter(logFileName);
            // Redirect the stdErr stream to write to your logfile
            Console.SetError(errStream);

            // Create the try/catch blocks
            // From the try portion, call the function, DivideByZero()
            try
            {
                DivideByZero();
            }
            // In the catch portion, write the error message contained in the exception object to the standard error stream
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                Console.Error.WriteLine(err);
            }

            // From the try portion, call the function, FileDoesNotExist()
            try
            {
                FileDoesNotExist();
            }
            // In the catch portion, write the error message contained in the exception object to the standard error stream
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                Console.Error.WriteLine(err);
            }

            // From the try portion, call the function, ArrayOutOfBounds()
            try
            {
                ArrayOutOfBounds();
            }
            // In the catch portion, write the error message contained in the exception object to the standard error stream
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                Console.Error.WriteLine(err);
            }

            // From the try portion, call the function, ArrayIsNull()
            try
            {
                ArrayIsNull();
            }
            // In the catch portion, write the error message contained in the exception object to the standard error stream
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                Console.Error.WriteLine(err);
            }

            // Close redirected error stream
            Console.Error.Close();

            // Call the DisplayLogFile() function to display the contents of the log file your program has created.
            DisplayLogFile(logFileName);

            // Keep the console window open
            Console.ReadLine();
        }

        // Create a function, DisplayLogFile(), that will read the logfile and display its contents to the console.
        public static void DisplayLogFile(string logFileName)
        {
            // Read log file contents
            using (FileStream fileStream = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                while (!streamReader.EndOfStream)
                {
                    Console.WriteLine(streamReader.ReadLine());
                }
            }
        }

        // Create a function named, DivideByZero(), which will attempt to divide a number by 0.
        public static void DivideByZero()
        {
            // Produce a divide by zero error
            int num1 = 15;
            int num2 = 0;
            int sum = num1 / num2;
        }

        // Create a function named, FileDoesNotExist(), which will attempt to open a non-existent file named, "NoFileNamedThis.txt".
        public static void FileDoesNotExist()
        {
            // Produce a file does not exist error
            int lineCounter = 0;
            using (System.IO.StreamReader file = new System.IO.StreamReader("NoFileNamedThis.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    lineCounter++;
                }
            }
        }

        // Create a function named, ArrayOutOfBounds(), which will create an array and then try to access a non-existent index in that array.
        public static void ArrayOutOfBounds()
        {
            // Produce an array out of bounds error
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };
            for (int i = 0; i <= names.Length; i++)
            {
                string SomeName = names[i];
            }
        }

        // Create a function named ArrayIsNull(), which will create an array and then set it equal to null before trying to access an item in the array.
        public static void ArrayIsNull()
        {
            // Produce an array is null error
            string[] names = { "Ed", "Fred", "Ted", "Mel", "Stan" };
            names = null;
            string SomeName = names[2];
        }
    }
}