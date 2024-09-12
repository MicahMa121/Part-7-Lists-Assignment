using System.Diagnostics.CodeAnalysis;

namespace Part_7_Lists_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random gen = new Random();
            List<int> integers = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                integers.Add(gen.Next(10,21));
            }
            Console.WriteLine("Here's the list of integers:");
            Console.WriteLine(string.Join(",", integers));
            Console.WriteLine("1 – Sort the list\r\n" +
                "2 – Make a new list of random numbers\r\n" +
                "3 – Remove a number (by value)\r\n" +
                "4 – Add a value to the list\r\n" +
                "5 – Count the number of occurrences of a specified number\r\n" +
                "6 – Print the largest value\r\n" +
                "7 – Print the smallest value\r\n" +
                "8 – Quit\r\n" +
                "9 – Print the sum and average of the numbers in the list\r\n" +
                "10 - Determine the most frequently occurring value(s)\r\n" );
            int option;
            while (!int.TryParse(Console.ReadLine(),out option)||option > 11||option < 1)
            {
                Console.WriteLine("Please enter a valid input.");
            }
            switch (option)
            {
                case 1:
                    integers.Sort();
                    break;
                case 2:
                    for (int i = 0; i < 30; i++)
                    {
                        integers[i] = gen.Next(10, 21);
                    }
                    break;
                case 3:
                    int num_to_remove;
                    Console.WriteLine("Please enter the number you would like to remove!(10-20 inclusive)");
                    while (!int.TryParse(Console.ReadLine(), out num_to_remove)||num_to_remove>20||num_to_remove<10)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    bool Remove(int x)
                    {
                        return x == num_to_remove;
                    }
                    integers.RemoveAll(Remove);
                    break;
                case 4:
                    Console.WriteLine("Please enter the number you would like to add to the list!");
                    int num_to_add;
                    while (!int.TryParse(Console.ReadLine(), out num_to_add) )
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    integers.Add(num_to_add);
                    break;
                case 5:
                    int num_to_count;
                    int count = 0;
                    Console.WriteLine("Please enter the number you want to count!(10-20 inclusive)");
                    while (!int.TryParse(Console.ReadLine(), out num_to_count) || num_to_count > 20 || num_to_count < 10)
                    {
                        Console.WriteLine("Please enter a valid number");
                    }
                    foreach (var item in integers)
                    {
                        if (item == num_to_count)
                        {
                            count++;
                        }
                    }
                    Console.WriteLine("The number " + num_to_count + " occurred " + count + " times in this list.");
                    break;
                case 6:
                    integers.Sort();
                    Console.WriteLine("The largest number in this list is " + integers[integers.Count-1]+ "!");
                    break;
                case 7:
                    integers.Sort();
                    Console.WriteLine("The smallest number in this list is " + integers[0] + "!");
                    break;
                case 8:
                    Console.WriteLine("Thank You for using this program!");
                    Environment.ExitCode = 0;
                    break;
                case 9:
                    int sum = integers.Sum();
                    Console.WriteLine("The sum of this list is " + sum + ", and the average is " + sum / integers.Count + "!");
                    break;
                case 10:
                    integers.Sort();
                    int answer = 0;
                    int prev=0;
                    int most_occurrence = 0;
                    int occurrence =0;
                    for (int i = 0; i < integers.Count; i++)
                    {
                        if (integers[i] == prev)
                        {
                            occurrence++;
                        }
                        else
                        {
                            prev = integers[i];
                            occurrence = 1;
                        }
                        if (occurrence > most_occurrence)
                        {
                            most_occurrence = occurrence;
                            answer = prev;
                        }
                    }
                    Console.WriteLine("The most frequently occurring number is " + answer + ", which occurred " + most_occurrence + " times in the list.");
                    break;

            }
            Console.WriteLine("Here's the updated list of integers:");
            Console.WriteLine(string.Join(",", integers));
        }


    }
}
