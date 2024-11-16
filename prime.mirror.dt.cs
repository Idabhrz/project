using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Check Prime Number");
            Console.WriteLine("2 - Check Mirror Number");
            Console.WriteLine("3 - Decision Tree");
            Console.WriteLine("0 - Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CheckPrimeNumber();
                    break;
                case "2":
                    CheckMirrorNumber();
                    break;
                case "3":
                    DecisionTree();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void CheckPrimeNumber()
    {
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            bool isPrime = IsPrime(number);
            Console.WriteLine(isPrime ? $"{number} is a prime number." : $"{number} is not a prime number.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    static void CheckMirrorNumber()
    {
        Console.Write("Enter a number: ");
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            bool isMirror = IsMirrorNumber(number);
            Console.WriteLine(isMirror ? $"{number} is a mirror number." : $"{number} is not a mirror number.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static bool IsMirrorNumber(int number)
    {
        int original = number;
        int reversed = 0;

        while (number > 0)
        {
            int digit = number % 10;
            reversed = reversed * 10 + digit;
            number /= 10;
        }

        return original == reversed;
    }

    static void DecisionTree()
    {
        Console.WriteLine("Answer the following questions with 'yes' or 'no':");

        Console.Write("Is it raining? ");
        string answer1 = Console.ReadLine().ToLower().Trim();

        Console.Write("Do you have an umbrella? ");
        string answer2 = Console.ReadLine().ToLower().Trim();

        Console.Write("Are you going outside? ");
        string answer3 = Console.ReadLine().ToLower().Trim();


        if (answer1 == "yes")
        {
            if (answer2 == "yes")
            {
                Console.WriteLine("You can go outside with your umbrella.");
            }
            else if (answer2 == "no")
            {
                if (answer3 == "yes")
                {
                    Console.WriteLine("You should stay inside.");
                }
                else if (answer3 == "no")
                {
                    Console.WriteLine("You are safe at home.");
                }
                else
                {
                    Console.WriteLine("Invalid input for going outside.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for umbrella.");
            }
        }
        else if (answer1 == "no")
        {
            if (answer3 == "yes")
            {
                Console.WriteLine("You can go outside.");
            }
            else if (answer3 == "no")
            {
                Console.WriteLine("You are safe at home.");
            }
            else
            {
                Console.WriteLine("Invalid input for going outside.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input for rain question.");
        }
    }
}
