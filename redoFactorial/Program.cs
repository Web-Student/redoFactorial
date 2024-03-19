using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Numerics;

namespace PSP_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Program().PerformTwoFactorialTasks();
        }

        private void PerformTwoFactorialTasks()
        {
            string fileWithResults = WriteNumbersOneToNFactorialToFile(14);
            BigInteger? ResultFromFactorial = null;
            int? numFromFile = ReadNumberFromFile();


            //print results:
            Console.WriteLine("You can find a file with the factorial of 1 - 14 in the file " + fileWithResults);
            if (numFromFile is null)
            {
                Console.WriteLine("There was an error reading a number from the file. Either the file was not there, did not have just an integer in it, or the number was too big.");
            }
            else
            {
                Console.WriteLine($"The factorial of {numFromFile} is {Factorial((int)numFromFile)}");
            }
        }

        private string WriteNumbersOneToNFactorialToFile(int n)
        {
            string filename = "FactorialResults.txt";
            StreamWriter writer = new StreamWriter("FactorialResults.txt", append: true);
            writer.WriteLine(string.Format("{0}{1,19}{2,-20}", "factorial", "|", "number"));
            for (int i = 0; i < n; i++)
            {
                //{indentCharacters, number to write}
                //writer.WriteLine("{ 0, i}{19, '|'}{20, factorial(i)}", i, factorial(i)); //call the factorial here
                writer.WriteLine(string.Format("{0}{1,19}{2,-20}", Factorial(i), "|", i));
                writer.WriteLine("we are writing something");
            }
            return filename;
        }

        private BigInteger Factorial(int n)
        {
            if (n <= 0)
            {
                return BigInteger.One;
            }
            else
            {
                return BigInteger.Multiply(new BigInteger((int)n), Factorial(n - 1));
            }
        }

        private int? ReadNumberFromFile()
        {
            string result = "";
            try
            {
                StreamReader reader = new StreamReader("NumberToRead.txt");
                result = reader.ReadToEnd();
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            //catch
            //{
            //    //all other exceptions
            //    return null;
            //}
            if (!Int32.TryParse(result, out int number))
            {
                return null;
            }
            return number;
        }
    }
}
