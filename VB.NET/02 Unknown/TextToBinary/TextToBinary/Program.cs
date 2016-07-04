using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextToBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the string to convert to binary.");
            Console.Write("> ");

            while (true)
            {
                Console.WriteLine(ConvertToBinary(Console.ReadLine()));
                Console.Write("> ");

            }

        }

        private static string ConvertToBinary(string textToConvert)
        {
            string result = "";
            byte[] arr = Encoding.ASCII.GetBytes(textToConvert);

            //result = arr.ToString();

            /*
            foreach (byte thing in arr)
            {
                result = result + thing;
            }
            */

            for (int i = 0; i == arr.GetUpperBound(0); i++)
            {
                result = result + arr[i].ToString();
            }


            return result;

        }

    }
}
