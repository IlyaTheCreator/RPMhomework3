using System;

namespace consoleapp
{
    class Program
    {
        // TESTING
        public static void Main(string[] args)
        {
            // Initial vars
            var intList = new List<int>();
            var stringList = new List<string>();
            var random = new Random();
            
            // Filling the lists with random values
            for (var i = 0; i < 10; i++)
                intList.Add(random.Next(-100, 100));

            stringList.Add("hello");
            stringList.Add("world");
            stringList.Add("from");
            stringList.Add("iluha");
            stringList.Add("bruh");

            // Printing the lists to the console
            Console.WriteLine("List of integers:");
            
            for (var i = 0; i < intList.Length; i++)
                Console.Write($"{intList[i]} ");
            
            Console.WriteLine("");
            Console.WriteLine("List of strings:");
            
            for (var i = 0; i < stringList.Length; i++)
                Console.Write($"{stringList[i]} ");
            
            Console.WriteLine("");
            
            // Deleting items randomly 
            try
            {
                intList.RemoveAt(random.Next(-1, 12));
                stringList.RemoveAt(random.Next(-1, 6));
                
                // Printing again
                Console.WriteLine("List of integers:");
            
                for (var i = 0; i < intList.Length; i++)
                    Console.Write($"{intList[i]} ");
            
                Console.WriteLine("");
                Console.WriteLine("List of strings:");
            
                for (var i = 0; i < stringList.Length; i++)
                    Console.Write($"{stringList[i]} ");
            
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while removing: index out of range");
            }
        }
    }
}