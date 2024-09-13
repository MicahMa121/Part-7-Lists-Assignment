using System.Diagnostics.CodeAnalysis;

namespace Part_7_Lists_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, please choose the program you would like to run!");
            Console.WriteLine("1 - Lists of integers \n2 - Lists of strings");
            int welcome;
            while (!int.TryParse(Console.ReadLine(),out welcome)||(welcome !=1 &&welcome != 2))
            {
                Console.WriteLine("Please enter a valid number");
            }
            if (welcome == 1)
            {
                ListIntegers();
            }
            else
            {
                ListString();
            }
        }
        public static void ListIntegers()
        {
            Random gen = new Random();
            List<int> integers = new List<int>();
            for (int i = 0; i < 30; i++)
            {
                integers.Add(gen.Next(10, 21));
            }
            Console.WriteLine("Here's the list of integers:");
            Console.WriteLine(string.Join(",", integers));
            do
            {
                Console.WriteLine("1 – Sort the list\r\n" +
                "2 – Make a new list of random numbers\r\n" +
                "3 – Remove a number (by value)\r\n" +
                "4 – Add a value to the list\r\n" +
                "5 – Count the number of occurrences of a specified number\r\n" +
                "6 – Print the largest value\r\n" +
                "7 – Print the smallest value\r\n" +
                "8 – Quit\r\n" +
                "9 – Print the sum and average of the numbers in the list\r\n" +
                "10 - Determine the most frequently occurring value(s)\r\n");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option > 11 || option < 1)
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
                        while (!int.TryParse(Console.ReadLine(), out num_to_remove) || num_to_remove > 20 || num_to_remove < 10)
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
                        while (!int.TryParse(Console.ReadLine(), out num_to_add))
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
                        Console.WriteLine("The largest number in this list is " + integers[integers.Count - 1] + "!");
                        break;
                    case 7:
                        integers.Sort();
                        Console.WriteLine("The smallest number in this list is " + integers[0] + "!");
                        break;
                    case 8:
                        Console.WriteLine("Thank You for using this program!");
                        Environment.Exit(0);
                        break;
                    case 9:
                        int sum = integers.Sum();
                        Console.WriteLine("The sum of this list is " + sum + ", and the average is " + sum / integers.Count + "!");
                        break;
                    case 10:
                        integers.Sort();
                        List<int> answer = new List<int>();
                        int prev = 0;
                        int most_occurrence = 0;
                        int occurrence = 0;
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
                            if (occurrence == most_occurrence)
                            {
                                answer.Add(prev);
                            }
                            if (occurrence > most_occurrence)
                            {
                                most_occurrence = occurrence;
                                answer.Clear();
                                answer.Add(prev);
                            }
                        }
                        Console.WriteLine("The most frequently occurring number is " + string.Join(" and ", answer) + ", which occurred " + most_occurrence + " times in the list.");
                        break;

                }
                Console.WriteLine("Here's the updated list of integers:");
                Console.WriteLine(string.Join(",", integers));
                Console.WriteLine();
            }
            while (true);
        }
        public static void ListString()
        {
            List<string> veges = new List<string>();
            veges.Add("carrot");
            veges.Add("beet");
            veges.Add("celery");
            veges.Add("raddish");
            veges.Add("cabbage");

            do
            {
                Console.WriteLine("List of Vegetables:");
                for (int i = 0; i < veges.Count; i++)
                {
                    Console.WriteLine((i + 1) + " - " + veges[i].ToUpper());
                }
                Console.WriteLine();
                Console.WriteLine("1 - Remove a vegetable by entering its index\n" +
                    "2 - Remove a vegetable by entering its name\n" +
                    "3 - Search for a vegetable by its name\n" +
                    "4 - Add a vegetable\n" +
                    "5 - Sort the list\n" +
                    "6 - Clean the list\n" +
                    "7 - Quit the program");
                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option > 7 || option < 1)
                {
                    Console.WriteLine("Please enter a valid input.");
                }
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Please enter the index of the vegetable you want to remove!");
                        int index;
                        while (!int.TryParse(Console.ReadLine(), out index) || index > veges.Count || index < 1)
                        {
                            Console.WriteLine("Please enter a valid index.");
                        }
                        veges.RemoveAt(index);
                        break;
                    case 2:
                        Console.WriteLine("Please enter the vegetable you want to remove!");
                        string vege_to_remove = Console.ReadLine();
                        if (string.IsNullOrEmpty(vege_to_remove))
                        {
                            Console.WriteLine("Empty Input");
                            break;
                        }
                        if (veges.Remove(vege_to_remove.ToLower()))
                        {
                            Console.WriteLine(vege_to_remove.ToUpper() + " is removed from the list.");
                        }
                        else
                        {
                            Console.WriteLine(vege_to_remove.ToUpper() + " is not found in the list.");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Please enter the vegetable you want to search!");
                        string vege_to_search = Console.ReadLine();
                        if (string.IsNullOrEmpty(vege_to_search))
                        {
                            Console.WriteLine("Empty Input");
                            break;
                        }
                        bool find(string s)
                        {
                            return s == vege_to_search.ToLower();
                        }
                        if (veges.FindIndex(find) != -1)
                        {
                            Console.WriteLine("The index of " + vege_to_search.ToUpper() + " is " + (veges.FindIndex(find) + 1) + "!");
                        }
                        else
                        {
                            Console.WriteLine(vege_to_search.ToUpper() + " is not found in the list.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please enter the vegetable you want to add!");
                        string vege_to_add = Console.ReadLine().ToLower();
                        if (string.IsNullOrEmpty(vege_to_add))
                        {
                            Console.WriteLine("Empty Input");
                            break;
                        }
                        if (veges.Contains(vege_to_add.ToLower()))
                        {
                            Console.WriteLine(vege_to_add.ToUpper() + " is already in the list.");

                        }
                        else
                        {
                            veges.Add(vege_to_add);
                            Console.WriteLine(vege_to_add.ToUpper() + " is added to the list.");
                        }
                        break;
                    case 5:
                        veges.Sort();
                        Console.WriteLine("The list is sorted.");
                        break;
                    case 6:
                        veges.Clear();
                        Console.WriteLine("The list is cleared.");
                        break;
                    case 7:
                        Console.WriteLine("Thank You for using this program!");
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
            while (true);
        }
    }
}
