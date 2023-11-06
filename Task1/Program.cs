using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PrintFirstCharacter();
        }
        static void PrintFirstCharacter()
        {
            try
            {
                Console.WriteLine("Enter a word");
                string input = Console.ReadLine();

                while (!string.IsNullOrEmpty(input))
                {
                    Console.WriteLine(input[0]);
                    Console.WriteLine("Enter another word");
                    input = Console.ReadLine();                    
                }
                Console.WriteLine(input[0]);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions.
                Console.WriteLine(ex.Message);
            }
        }

    }
}